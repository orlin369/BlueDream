using DiO_CS_BTConf.Bluetooth;
using DiO_CS_BTConf.Bluetooth.BlueSMiRF;
using DiO_CS_BTConf.Bluetooth.Communication;
using DiO_CS_BTConf.Bluetooth.HCSeries;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace DiO_CS_BTConf
{
    public partial class MainForm : Form
    {

        #region Variables

        /// <summary>
        /// Bluetooth
        /// </summary>
        private BluetoothDevice bluetooth;

        /// <summary>
        /// Serial port name.
        /// </summary>
        private string portName = "COM1";

        /// <summary>
        /// Bluetooth type
        /// </summary>
        BluetoothTypes bluetoothType = BluetoothTypes.HC06;

        /// <summary>
        /// Settings path and name.
        /// </summary>
        private string settingsName = "";

        /// <summary>
        /// Sync keys input to the field.
        /// </summary>
        private bool pinEventLock = false;

        /// <summary>
        /// 
        /// </summary>
        private int value = 0;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #endregion

        #region Private

        private void SearchForPorts()
        {
            this.portsToolStripMenuItem.DropDown.Items.Clear();

            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();

            if (portNames.Length == 0)
            {
                return;
            }

            foreach (string item in portNames)
            {
                //store the each retrieved available prot names into the MenuItems...
                this.portsToolStripMenuItem.DropDown.Items.Add(item);
            }

            foreach (ToolStripMenuItem item in this.portsToolStripMenuItem.DropDown.Items)
            {
                item.Click += mItPorts_Click;
                item.Enabled = true;
                item.Checked = false;
            }
        }

        private void ConnectToDevice()
        {
            try
            {
                if (this.bluetoothType == BluetoothTypes.HC05)
                {
                    this.bluetooth = new BluetoothDevice(new HC05(this.portName));
                }
                else if (this.bluetoothType == BluetoothTypes.HC06)
                {
                    this.bluetooth = new BluetoothDevice(new HC06(this.portName));
                }
                else if (this.bluetoothType == BluetoothTypes.RN21)
                {
                    this.bluetooth = new BluetoothDevice(new RN21(this.portName));
                }

                this.bluetooth.SetRecieveEvent(this.bluetooth_RecievedMessage);
                this.bluetooth.SetMessageEvent(this.bluetooth_SentMessage);

                this.bluetooth.Connect();
            }
            catch (Exception exception)
            {
                //this.AddLogRow(exception.ToString());
            }
        }

        private void DisconnectFromDevice()
        {
            try
            {
                if (this.bluetooth != null && this.bluetooth.IsConnected)
                {
                    this.bluetooth.Disconnect();
                }
            }
            catch (Exception exception)
            {
                //this.AddLogRow(exception.ToString());
            }
        }

        private void AddLogRow(string message)
        {
            string dateAndTime = DateTime.Now.ToString("yyyy.MM.dd/HH:mm:ss.fff", System.Globalization.DateTimeFormatInfo.InvariantInfo);

            string onScreenMsg = String.Format("{0} -> {1}", dateAndTime, message);

            if (this.lstLog.InvokeRequired)
            {
                this.lstLog.BeginInvoke((MethodInvoker)delegate()
                {
                    this.lstLog.Items.Add(onScreenMsg);
                });
            }
            else
            {
                this.lstLog.Items.Add(onScreenMsg);
            }
        }

        private void CommandParser(string command)
        {
            if (!command.Contains("OK"))
            {
                //string text = String.Format("Comman \"{0}\" not accepted.", command);
                //MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetType()
        {
            string type = this.bluetoothType.ToString();
            this.lblType.Text = String.Format("Type: {0}", type);
        }

        private void SetConnectivity()
        {
            if (this.bluetooth.IsConnected)
            {
                this.lblIsConnected.Text = String.Format("Connected: {0}", this.portName);
            }
            else
            {
                this.lblIsConnected.Text = "Not Connected";
            }
        }

        private string CreateProgramName()
        {
            DateTime time = DateTime.Now;             // Use current time.
            string format = "yyMMddHHmmss";   // Use this format.
            return "BlueDream_" + time.ToString(format);
        }

        private void SaveSettings()
        {
            // Create an instance of the open file dialog box.
            SaveFileDialog fileDialog = new SaveFileDialog();

            // Set filter options and filter index.
            fileDialog.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;

            if (this.settingsName == "")
            {
                this.settingsName = this.CreateProgramName();
            }

            fileDialog.FileName = this.settingsName;
            //fileDialog.Multiselect = false;

            // Show the dialog and get result.
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK && this.bluetooth != null) // Test result.
            {
                string path = fileDialog.FileName;
                SettingManager.Save(this.bluetooth, path);
            }
        }

        private void LoadProgram()
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog fileDialog = new OpenFileDialog();

            // Set filter options and filter index.
            fileDialog.Filter = "XML Files (.xml)|*.xml|All Files (*.*)|*.*";
            fileDialog.FilterIndex = 1;
            fileDialog.Multiselect = false;

            // Show the dialog and get result.
            DialogResult result = fileDialog.ShowDialog();

            if (result == DialogResult.OK) // Test result.
            {
                string path = fileDialog.FileName;
                throw new NotImplementedException("Not finished!");
                //this.bluetooth = SettingManager.Load<HC06>(path);
            }
        }

        private bool ValidatePin(string pin)
        {
            return false;
        }

        #endregion

        #region Bluetooth

        private void bluetooth_SentMessage(object sender, MessageString e)
        {
            this.CommandParser(e.Message);
            this.AddLogRow(e.Message);
        }

        private void bluetooth_RecievedMessage(object sender, MessageString e)
        {
            this.CommandParser(e.Message);
            this.AddLogRow(e.Message);
        }

        #endregion

        #region Menu Items

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SearchForPorts();
        }

        private void mItPorts_Click(object sender, EventArgs e)
        {
            this.DisconnectFromDevice();
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.portName = item.Text;
            this.ConnectToDevice();

            item.Checked = this.bluetooth.IsConnected;
            this.SetConnectivity();
            this.SetType();
        }

        private void mItType_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem item = (ToolStripMenuItem)sender;
            this.bluetoothType = (BluetoothTypes)Enum.Parse(typeof(BluetoothTypes), item.Text);
            this.lblType.Text = this.bluetoothType.ToString();
            this.DisconnectFromDevice();

            if (this.bluetoothType == BluetoothTypes.HC06)
            {
                this.bluetooth = new BluetoothDevice(new HC06(this.portName));
            }
            else if (this.bluetoothType == BluetoothTypes.HC05)
            {
                this.bluetooth = new BluetoothDevice(new HC05(this.portName));
            }
            else if (this.bluetoothType == BluetoothTypes.RN21)
            {
                this.bluetooth = new BluetoothDevice(new RN21(this.portName));
            }

            this.bluetooth.SetRecieveEvent(this.bluetooth_RecievedMessage);
            this.bluetooth.SetMessageEvent(this.bluetooth_SentMessage);

            item.Checked = this.bluetooth.IsConnected;
            this.SetConnectivity();
            this.SetType();
        }
        
        #endregion

        #region Main Form

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.bluetooth = new BluetoothDevice(new HC06(this.portName));

            this.SearchForPorts();

            if (this.cmbBoudRate.Items.Count > 0)
            {
                this.cmbBoudRate.Text = (string)this.cmbBoudRate.Items[3];
            }

            //store the each retrieved available prot names into the MenuItems...
            IEnumerable list = Enum.GetValues(typeof(BluetoothTypes));
            foreach (BluetoothTypes item in list)
            {
                this.typeToolStripMenuItem.DropDown.Items.Add(item.ToString());
            }

            foreach (ToolStripMenuItem item in this.typeToolStripMenuItem.DropDown.Items)
            {
                item.Click += mItType_Click;
                item.Enabled = true;
                item.Checked = false;
            }

            this.SetType();
        }

        #endregion

        #region Buttons

        private void btnSetName_Click(object sender, EventArgs e)
        {
            if (this.bluetooth.IsConnected)
            {
                this.SetConnectivity();
                this.bluetooth.SetName(this.txtName.Text);
            }
        }

        private void btnSetPin_Click(object sender, EventArgs e)
        {
            if (this.bluetooth.IsConnected)
            {
                this.bluetooth.SetPin(this.txtPin.Text);
            }
        }

        private void btnSetBoudRate_Click(object sender, EventArgs e)
        {
            if (this.bluetooth.IsConnected)
            {
                this.bluetooth.SetBaudRate(this.cmbBoudRate.SelectedIndex + 1);
            }
        }

        private void btnEnterCommandMode_Click(object sender, EventArgs e)
        {
            if (this.bluetooth.IsConnected)
            {
                this.bluetooth.EnterCommandMode();
            }
        }

        private void btnSetAll_Click(object sender, EventArgs e)
        {
            Thread worker = new Thread(new ThreadStart(
                delegate()
                {
                    
                    if (this.bluetooth.IsConnected)
                    {
                        this.bluetooth.EnterCommandMode();
                        Thread.Sleep(2000);
                        this.bluetooth.SetName(this.txtName.Text);
                        Thread.Sleep(2000);
                        this.bluetooth.SetPin(this.txtPin.Text);
                        Thread.Sleep(2000);
                        //this.bluetooth.SetBaudRate(this.cmbBoudRate.SelectedIndex + 1);
                    }
                }));
            worker.Start();
        }

        private void btnSendRaw_Click(object sender, EventArgs e)
        {
            //TODO: Send raw data.
            this.bluetooth.SendRawRequest(this.txtRawMessage.Text);
        }

        #endregion

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.SaveSettings();
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisconnectFromDevice();
            this.LoadProgram();
        }

        private void txtPin_KeyUp(object sender, KeyEventArgs e)
        {
            
            // Locker
            if (this.pinEventLock)
            {
                return;
            }
            this.pinEventLock = true;

            //
            string textData = this.txtPin.Text;
            bool res = false;

            if (e.KeyData == Keys.Back)
            {
                this.pinEventLock = false;
                return;
            }

            if (textData.Length > 0 && textData.Length < 5)
            {
                res = int.TryParse(textData, out value);

                if (!res)
                {
                    e.Handled = true;
                }
            }

            // Data validator
            if (((e.KeyData == Keys.Enter) || (textData.Length == 4)) && res)
            {
                //this.txtPin.BackColor = Color.Green;

                if (this.bluetooth != null && this.bluetooth.IsConnected)
                {
                    //TODO: Send pin to bluetooth.
                }
            }
            else
            {
                //this.txtPin.BackColor = Color.Red;
            }

            this.pinEventLock = false;
        }
    }
}

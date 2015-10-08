using DiO_CS_BTConf.Bluetooth.Communication;
using System;
using System.IO.Ports;

namespace DiO_CS_BTConf.Bluetooth.HCSeries
{
    public class HC05 : Communicator
    {

        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName">Port name.</param>
        public HC05(string portName)
            : base(portName)
        {

        }

        #endregion

        #region AT Calls

        /// <summary>
        /// Enter AT mode.
        /// </summary>
        public void CheckATStatus()
        {
            this.SendRequest("AT");
        }

        public void Reset()
        {
            this.SendRequest("AT+RESET");
        }

        public void GetVersion()
        {
            this.SendRequest("AT+VERSION?");
        }

        public void RestorDefault()
        {
            this.SendRequest("AT+ORGL?");
        }

        public void GetAddress()
        {
            this.SendRequest("AT+ADDR?");
        }

        public void SetName(string name)
        {
            if ((name == null) || (name.Length == 0))
            {
                return;
            }
            string command = String.Format("AT+NAME{0}", name);
            this.SendRequest(command);
        }

        public void GetRemoteDevices()
        {
            this.SendRequest("AT+RNAME?");
        }

        public void GetRole()
        {
            this.SendRequest("AT+ROLE?");
        }

        public void SetRole(int role = 0)
        {
            if (role > 2 || role < 0)
            {
                return;
            }

            string command = String.Format("AT+ROLE={0}", role);
            this.SendRequest(command);
        }

        public void GetClass()
        {
            this.SendRequest("AT+CALSS?");
        }

        public void SetClass(uint index = 0)
        {
            string command = String.Format("AT+CALSS={0}", index);
            this.SendRequest(command);
        }

        public void GetInquireAccessCode()
        {
            this.SendRequest("AT+IAC?");
        }

        public void SetInquireAccessCode(string code)
        {
            string command = String.Format("AT+IAC={0}", code);
            this.SendRequest(command);
        }

        public void GetInquireAccessMode()
        {
            this.SendRequest("AT+INQM?");
        }

        public void SetInquireAccessMode(string code)
        {
            string command = String.Format("AT+INQM={0}", code);
            this.SendRequest(command);
        }

        public void GetPassword()
        {
            this.SendRequest("AT+PSWD?");
        }

        public void SetPassword(string pass)
        {
            string command = String.Format("AT+PSWD={0}", pass);
            this.SendRequest(command);
        }

        public void GetUart()
        {
            this.SendRequest("AT+UART?");
        }

        public void SetUart(int boudRate, int stopBits, int parity)
        {
            string command = String.Format("AT+UART={0},{1},{2}", boudRate, stopBits, parity.ToString());
            this.SendRequest(command);
        }

        #endregion

    }
}

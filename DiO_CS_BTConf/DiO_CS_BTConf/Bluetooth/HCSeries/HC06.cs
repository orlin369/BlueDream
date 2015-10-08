using DiO_CS_BTConf.Bluetooth.Communication;
using System;

namespace DiO_CS_BTConf.Bluetooth.HCSeries
{
    [Serializable]
    public class HC06 : Communicator
    {

        #region Constructor

        /// <summary>
        /// Construcotr
        /// </summary>
        public HC06() : base("COM1")
        {

        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName">Port name.</param>
        public HC06(string portName)
            : base(portName)
        {

        }

        #endregion

        #region AT calls

        /// <summary>
        /// Enter AT mode.
        /// </summary>
        public void CheckATStatus()
        {
            this.SendRequest("AT");
        }

        /// <summary>
        /// Set the boud rate of the device.
        /// </summary>
        /// <param name="baudRate">Boud rate.</param>
        /// <remarks>
        /// 1 - 1200 
        /// 2 - 2400 
        /// 3 - 4800 
        /// 4 - 9600 
        /// 5 - 19200 
        /// 6 - 38400 
        /// 7 - 57600 
        /// 8 - 115200 
        /// </remarks>
        public void SetBaudRate(int baudRateIndex)
        {
            string command = String.Format("AT+BAUD{0}", baudRateIndex);
            this.SendRequest(command);
        }

        /// <summary>
        /// Set the name of the device.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            if ((name == null) || (name.Length == 0))
            {
                return;
            }
            string command = String.Format("AT+NAME{0}", name);
            this.SendRequest(command);
        }

        /// <summary>
        /// Set the name of the device.
        /// </summary>
        /// <param name="btName"></param>
        public void SetPin(string pin)
        {
            if ((pin == null) || (pin.Length < 4) || (pin.Length > 4))
            {
                return;
            }

            string command = String.Format("AT+PIN{0}", pin);
            this.SendRequest(command);
        }

        #endregion

    }
}

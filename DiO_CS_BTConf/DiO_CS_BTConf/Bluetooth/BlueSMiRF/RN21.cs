using DiO_CS_BTConf.Bluetooth.Communication;
using System;

namespace DiO_CS_BTConf.Bluetooth.BlueSMiRF
{
    /// <summary>
    /// The commands are all single or 2 character, generally comma delimited.
    /// Commands and hex input data can be upper or lower case.
    /// Text data, such as Bluetooth name, and pin code, are case sensitive.
    /// Commands fall into 4 general categories:  
    /// SET COMMANDS    - store information permanently and take effect after power cycle or software reset.
    /// GET COMMANDS    - retrieve the permanently stored information for display to the user.
    /// CHANGE COMMANDS - temporarily change the value of serial baudrate, parity, etc.
    /// ACTION COMMANDS - perform action such as inquiry, connect, etc
    /// </summary>
    public class RN21 : Communicator
    {
        
        #region Constructor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="portName"></param>
        public RN21(string portName)
            : base(portName)
        {

        }

        #endregion

        #region SET COMMANDS

        /// <summary>
        /// Name of device.
        /// </summary>
        /// <param name="name"></param>
        public void SetName(string name)
        {
            string command = String.Format("SS,{0}", name);
            this.SendRequest(command);
        }

        /// <summary>
        /// Pin of device.
        /// </summary>
        /// <param name="pin"></param>
        public void SetPin(string pin)
        {
            string command = String.Format("SP,{0}", pin);
            this.SendRequest(command);
        }


        /// <summary>
        /// ST,<num> - Config Timer, # of seconds (range=0 to 255 decimal, default = 60 decimal)
        /// to allow remote configuration over Bluetooth after power up in Slave Mode.
        /// In all Master modes, the remote config timer is set to 0 (no remote configuration).
        /// In Trigger Master Mode,  this Timer is used as an Idle timer
        /// to Break the connection after the timer expires with no characters being received.
        /// Example :  “ST,0” disables remote configuration
        /// Example :  “ST,255”enables remote configuration forever
        /// </summary>
        /// <param name="time">Time</param>
        public void SetTime(byte time)
        {
            string command = String.Format("ST,{0}", time);
            this.SendRequest(command);
        }

        /// <summary>
        /// SU,<rate> - Baudrate, {1200, 2400, 4800, 9600, 19.2, 38.4, 57.6, 115K, 230K, 460K, 921K }, only the first 2 characters are needed.  
        /// Example : “SU,96” sets the baudrate to 9600 buad.
        /// </summary>
        /// <param name="baudRate">Rate</param>
        public void SetBaudRate(int baudRate)
        {
            string command = String.Format("SU,{0}", baudRate);
            this.SendRequest(command);        
        }

        /// <summary>
        /// SW,<hex word> - Enable low power SNIFF mode. Default is 0000=disabled.
        /// SNIFF mode allows extreme low power operation.
        /// Device goes into a deep sleep, and wakes up every every 625us * <hex word>  to send/receive chars.
        /// Example: “SW,0050” enables Sniff mode and sets the interval time to 50 hex * .625 = 50 milliseconds.
        /// This will cause the module to enter low power sleep,
        /// and wake once every 50 milliseconds to check for RF activity.
        /// See Section 4.1 for more details on Sniff.
        /// </summary>
        public void EnableLPSniff(int operation)
        {
            string hexValue = operation.ToString("X4");
            string command = String.Format("SW,{0}", hexValue);
            this.SendRequest(command);        
        }

        /// <summary>
        /// SX,<1,0> - Bonding enabled,   creates a single stored connection pair with a remote device.
        /// </summary>
        /// <param name="enable">Bonding state.</param>
        public void EnabledBonding(bool enable)
        {
            string value = enable ? "1" : "0";
            string command = String.Format("SX,{0}", value);
            this.SendRequest(command);        
        }

        /// <summary>
        /// SZ,<num> - Raw Baudrate (decimal) allows entering of non - standard baudrates.   Based on the formula num = Baudrate * 0.004096.  
        /// </summary>
        /// <param name="baudRate">Rate</param>
        public void RawBaudrate(int baudRate)
        {
            string command = String.Format("SZ,{0}", baudRate);
            this.SendRequest(command);        
        }

        /// <summary>
        /// S~,<0,1> - Profile to use. 0=SPP (default), 1 = DUN DCE, 2 = DUN DTE, 3 = MDM. See Section 4.2 for more details on Profiles.
        /// </summary>
        /// <param name="profile"></param>
        public void SetProfile(int profile)
        {
            if(profile > 3 || profile < 0)
            {
                return;
            }

            string command = String.Format("S~,{0}", profile);
            this.SendRequest(command);        
        }

        /// <summary>
        /// S$,<char> - Configuration detect character.
        /// This allows a change from the default $$$ to some other character.
        /// Factory defaults returns the device to $$$.  
        /// </summary>
        /// <param name="sign">Char</param>
        public void ConfigurationDetect(char sign)
        {
            string command = String.Format("S$,{0}", sign);
            this.SendRequest(command);        
        }

        #endregion

        #region GET COMMANDS

        /// <summary>
        /// D - Display basic settings.  Address, Name, Uart Settings, Security, Pin code, Bonding, Remote Address.  This command  is an easy way to check the configuration.
        /// </summary>
        public void DisplaySettings()
        {
            this.SendRequest("D");
        }

        /// <summary>
        /// E - display extended settings. Service Name, Service Class, Device Class, Config Timer.
        /// </summary>
        public void DisplayExtended()
        {
            this.SendRequest("E");
        }

        /// <summary>
        /// M - display remote side modem signal status.
        /// </summary>
        public void DisplayRemote()
        {
            this.SendRequest("M");
        }

        /// <summary>
        /// O - display other settings. Config character, IOport values, debug mode.
        /// </summary>
        public void DisplayOtherSettings()
        {
            this.SendRequest("O");
        }

        /// <summary>
        /// G<X> - display stored settings. These commands correspond to the SET commands above.
        /// Example : “GS” will return 1 or 0 depending on the value of security.
        /// In addition to the above,  there are a fewother useful commands available.
        /// </summary>
        /// <param name="settingindex">Setting index</param>
        public void DisplayStoredSettings(int settingindex)
        {
            string command = String.Format("G{0}", settingindex);
            this.SendRequest(command);
        }

        /// <summary>
        /// GB - returns the Bluetooth Address of the device.
        /// </summary>
        public void BluetoothAddress()
        {
            this.SendRequest("GB");
        }

        /// <summary>
        /// GK - returns the current connection status: 1=connected, 0 = not connected.
        /// </summary>
        public void CurrentConnection()
        {
            this.SendRequest("GK");
        }

        /// <summary>
        /// G& -return a hex byte containing the value of the PIO Pins
        /// </summary>
        public void ByteContaining()
        {
            this.SendRequest("G&");
        }

        /// <summary>
        /// V - return the software release version
        /// </summary>
        public void SoftwareRelease()
        {
            this.SendRequest("V");
        }


        #endregion

        #region CHANGE COMMANDS

        /// <summary>
        /// U,<rate>,<E,O,N> - Temporary Uart Change, will change the serial parameters immediately,
        /// but not store them. Command will return “AOK” at curre nt settings,
        /// then automatically exit command mode, and switch to new baudrate.
        /// Example :  “U,9600,E” Sets baudrate to 9600, parity even.
        /// </summary>
        /// <param name="boudRate">Rate</param>
        /// <param name="parity">Parity</param>
        public void TemporaryUartChange(int boudRate, string parity)
        {
            string command = String.Format("U,{0},{1}", boudRate, parity);
            this.SendRequest(command);        
        }

        #endregion

        #region ACTION COMMANDS

        /// <summary>
        /// Run your favorite terminal emulator, HyperTerminal or other program.
        /// Type “$$$” on your screen. You should see “CMD” returned to you.
        /// This will verify that your cable and comm. settings are correct.
        /// Valid commands will return an “AOK”,  response, and invalid ones will return “ERR “.
        /// Commands that are not recognized will return a “?”.
        /// </summary>
        public void EnterCommandMode()
        {
            this.SendRequest("$$$");
        }

        /// <summary>
        /// To exit command mode, type “---“<cr>. (three minus signs).
        /// </summary>
        public void ExitCommandMode()
        {
            this.SendRequest("---\n");
        }

        /// <summary>
        /// C{,<address>} - connect The device will attempt to connect to the remote stored BT address,
        /// or an optional address can be entered directly.
        /// </summary>
        /// <param name="address"></param>
        public void ConnectToDevice(string address)
        {
            if (address != null)
            {
                return;
            }
            // TODO: C{,<address>}
            string command = String.Format("C{0}", address);
            this.SendRequest(command);        
        }

        /// <summary>
        /// CT<address>,<timer ( 1/4secs) > - connect with TIMER. The device will NOT use or store the remote address,
        /// rather will make a connection to the <address>  (REQUIRED).
        /// The device will automatically disconnect after 7 seconds if no data is seen from UART or BT.
        /// An optional timer value can be entered to change the default 7 seconds.
        /// This value is in ¼seconds. So for a 30 second timer,
        /// use 120 as the value.The maximum value is 255, or  64 seconds.
        /// </summary>
        /// <param name="address"></param>
        /// <param name="time"></param>
        public void ConnectWithTIMER(string address, int time)
        {
            if (time < 0 || address != null)
            {
                return;
            }
            string command = String.Format("CT{0},{1}", address, time);
            this.SendRequest(command);        
        }

        /// <summary>
        /// F,1 Go to FAST data mode, ends configuration immediately.
        /// </summary>
        /// <param name="mode"></param>
        public void FastDataMode(int mode)
        {
            if (mode < 0)
            {
                return;
            }
            string command = String.Format("F,{0}", mode);
            this.SendRequest(command);        
        }

        /// <summary>
        /// I<,time>,<cod>performs an inquiry scan. Default time is 10 seconds,
        /// maximum is 48.  Cod is optional class of device,
        /// 0 or no entry looks for all device classes.
        /// A maximum of 9 devices will be returned.
        /// As devices are found, they are displayed in the format below:<bt address>,  <bt name> , <cod>00A053000123,MySerialPort,72010C
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="code">Code</param>
        public void InquiryScan(int time, int code)
        {
            if (time < 0 || code < 0)
            {
                return;
            }
            string command = String.Format("I,{0},{1}", time, code);
            this.SendRequest(command);        
        }

        /// <summary>
        /// IN<time>,<cod> performs an inquiry scan,
        /// does not return the Bluetooth NAME
        /// (returns much faster, since name requires a remote lookup for each device found).
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="code">Code</param>
        public void InquiryScanNoName(int time, int code)
        {
            if (time < 0 || code < 0)
            {
                return;
            }
            string command = String.Format("IN,{0},{1}", time, code);
            this.SendRequest(command);
        }

        /// <summary>
        /// IR<time> performs an inquiry scan, with a COD of 0x001F00,
        /// which is the default COD forRoving Networks Serial adapters and modules.
        /// </summary>
        /// <param name="time">Time</param>
        public void InquiryScanCode(int time)
        {
            if (time < 0)
            {
                return;
            }
            string command = String.Format("IR,{0}", time);
            this.SendRequest(command);
        }


        /// <summary>
        /// IS<time> performs an inquiry scan, with a COD of 0x0055AA, which is the special COD usedBy Roving Networks Serial adapters and modules to enable “instant cable replacement”.
        /// </summary>
        /// <param name="time">Time</param>
        public void InquiryScanCode2(int time)
        {
            if (time < 0)
            {
                return;
            }
            string command = String.Format("IS,{0}", time);
            this.SendRequest(command);
        }

        /// <summary>
        /// H - help, will print out a list of commands and their basic syntaxK,
        /// Kill (disconnect) from the current connection.
        /// </summary>
        public void Help()
        {
            this.SendRequest("H");
        }

        /// <summary>
        /// P,<char> Pass thru, sends any chars along  up to a CR or LF while in command  mode.
        /// </summary>
        /// <param name="sign">Char</param>
        public void PassThru(char sign)
        {
            string command = String.Format("P,{0}", sign);
            this.SendRequest(command);
        }

        /// <summary>
        /// Q - Causes device to be non-discoverable and non-connectable (temporarily).
        /// Does not survive a power cycle or reset.  Used with the Z command below.
        /// </summary>
        public void CausesDevice()
        {
            this.SendRequest("Q");
        }

        /// <summary>
        /// R,1 forces a complete reboot of the device (similar to a power cycle)
        /// </summary>
        /// <param name="passUart">Enable UART</param>
        public void ReBoot(bool passUart)
        {
            string enableUart = passUart ? "1" : "0";
            string command = String.Format("R,{0}", enableUart);
            this.SendRequest(command);
        }

        /// <summary>
        /// T,<0,1> Pass receive data (from uart or BT) while in command mode.
        /// Returns (T=0 , T=1 based on input).
        /// </summary>
        /// <param name="passData">Enable data</param>
        public void PassRecieveData(bool passData)
        {
            string enableUart = passData ? "1" : "0";
            string command = String.Format("T,{0}", enableUart);
            this.SendRequest(command);
        }

        /// <summary>
        /// & - returns the value of the switches on BluePort, or value of PIO3,4,6,7 on other modules.
        /// </summary>
        public void PIO3()
        {
            this.SendRequest("&");
        }

        /// <summary>
        /// Z -Enters low power deep sleep mode (less then 2ma) when NOT connected.  Can only be exited by toggling the RESET pin on the module (causing a HARD reset) , or power cycling the device.  To get the lowest power mode, first issue a Q, then a Z.   Use the SNIFF settings to get lowest power while connected.
        /// </summary>
        public void EnterSleep()
        {
            this.SendRequest("Z");
        }

        #endregion

    }
}

using DiO_CS_BTConf.Bluetooth.Communication;
using System;
using System.Collections.Generic;

namespace DiO_CS_BTConf.Bluetooth
{
    public class BluetoothDevice
    {

        #region Variables

        /// <summary>
        /// 
        /// </summary>
        private object bluetooth = null;
        
        /// <summary>
        /// 
        /// </summary>
        private Type type = null;

        #endregion 

        #region Properties

        public bool IsConnected
        {
            get
            {
                bool isConnected = false;

                if (this.type == typeof(HCSeries.HC06))
                {
                    isConnected = ((HCSeries.HC06)this.bluetooth).IsConnected;
                }
                else if (this.type == typeof(HCSeries.HC05))
                {
                    isConnected = ((HCSeries.HC05)this.bluetooth).IsConnected;
                }
                else if (this.type == typeof(BlueSMiRF.RN21))
                {
                    isConnected = ((BlueSMiRF.RN21)this.bluetooth).IsConnected;
                }

                return isConnected;
            }
        }

        #endregion

        #region Construcotr

        public BluetoothDevice(object bluetooth)
        {
            if (bluetooth == null)
            {
                throw new ArgumentNullException("Must pass a valid bluetooth instance.");
            }

            this.bluetooth = bluetooth;
            this.type = this.bluetooth.GetType();
        }

        #endregion
        
        #region Public Methods

        public void SetName(string name)
        {
            if(this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).SetName(name);
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).SetName(name);
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).SetName(name);
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void SetPin(string pin)
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).SetPin(pin);
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).SetPassword(pin);
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).SetPin(pin);
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void SetBaudRate(int boudRate)
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).SetBaudRate(boudRate);
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                // TODO: Chech documentation for UART settings.
                ((HCSeries.HC05)this.bluetooth).SetUart(boudRate, 1, 0);
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).SetBaudRate(boudRate);
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void EnterCommandMode()
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).CheckATStatus();
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).CheckATStatus();
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).EnterCommandMode();
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void ExitCommandMode()
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).CheckATStatus();
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).CheckATStatus();
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).ExitCommandMode();
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void Connect()
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).Connect();
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).Connect();
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).Connect();
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void Disconnect()
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).Disconnect();
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).Disconnect();
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).Disconnect();
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void SendRawRequest(string command)
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).SendRawRequest(command);
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).SendRawRequest(command);
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).SendRawRequest(command);
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void SetRecieveEvent(EventHandler<MessageString> handler)
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).RecievedMessage += handler;
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).RecievedMessage += handler;
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).RecievedMessage += handler;
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        public void SetMessageEvent(EventHandler<MessageString> handler)
        {
            if (this.type == typeof(HCSeries.HC06))
            {
                ((HCSeries.HC06)this.bluetooth).SentMessage += handler;
            }
            else if (this.type == typeof(HCSeries.HC05))
            {
                ((HCSeries.HC05)this.bluetooth).SentMessage += handler;
            }
            else if (this.type == typeof(BlueSMiRF.RN21))
            {
                ((BlueSMiRF.RN21)this.bluetooth).SentMessage += handler;
            }
            else
            {
                throw new NotImplementedException("This method is not implemented for this model: " + this.type.Name);
            }
        }

        #endregion

    }
}

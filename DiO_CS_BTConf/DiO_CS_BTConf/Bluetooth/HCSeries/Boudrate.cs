using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DiO_CS_BTConf.Bluetooth.HCSeries
{
    
    /// <summary>
    /// Boudrate indexes.
    /// </summary>
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
    public enum Boudrate : int
    {
        B1200 = 1,
        B2400 = 2,
        B4800 = 3,
        B9600 = 4,
        B19200 = 5,
        B38400 = 6,
        B57600 = 7,
        B115200 = 8
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBitSketch.Enums
{
    [Flags]
    internal enum Terms
    {
        Hidden = 0b0000,
        Open = 0b0001,
        Win = 0b0010,
        Restricted = 0b0100,
        Bonus = 0b1000
    }
}

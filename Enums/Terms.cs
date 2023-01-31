using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBitSketch.Enums
{
    [Flags]
    internal enum Terms
    {
        Failed = 0b000,
        Win = 0b001,
        Restricted = 0b010,
        Bonus = 0b100
    }
}

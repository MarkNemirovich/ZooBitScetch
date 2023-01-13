using System;

namespace ZooBitScetch
{
    internal class Purse
    {
        public uint Money { get; private set; }
        public uint Diamonds { get; private set; }
        public Purse()
        {
            Money = 1000;
            Diamonds = 0;
        }
    }
}

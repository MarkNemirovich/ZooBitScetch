using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.PlayerThings
{
    internal interface IPayable
    {
        public int CheckAmount(Currency currency);
        public bool Pay(Currency currency, int cost);
    }
}

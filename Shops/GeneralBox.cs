using System;
using System.Xml.Linq;

namespace ZooBitSketch
{
    internal class GeneralBox : Box
    {
        public GeneralBox(int cost, Currency currency, BoxSize size) : base(cost, currency, size)
        {
        }
    }
}

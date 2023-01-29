using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using ZooBitSketch.Player;

namespace ZooBitSketch.PlayerThings
{
    internal interface ICustomer
    {
        public int GetLvl { get; }
        public void AddActive(Active active);
        public bool Purchase(Currency currency, int cost);
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace ZooBitSketch
{
    internal class Wardrobe<T> : AbstractPack<Clothes>
    {
        public List<Clothes> _clothes { get; private set; }
        public Wardrobe(int size) : base()
        {
            _clothes = new List<Clothes>();
        }
        sealed public override void Info()
        {
            base.Info();
        }
        sealed protected override void WriteList()
        {
            base.WriteList();
        }
    }
}

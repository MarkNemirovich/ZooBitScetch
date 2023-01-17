using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class Deck<T> : AbstractPack<Card>
    {
        public Deck(int size) : base(size)
        {
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

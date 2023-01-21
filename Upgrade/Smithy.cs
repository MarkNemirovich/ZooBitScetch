using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class Smithy : Workshop<Clothes>
    {
        public Smithy(List<Clothes> pack) : base(pack) { }

        protected override void PrintList()
        {
            for (int i = 0; i < AllSources.Count; i++)
            {
                var act = AllSources[i];
                Console.WriteLine($"{i} - {act.Name,-10} {act.Rareness,-10} {act.Genre,-10}");
            }
        }
    }
}
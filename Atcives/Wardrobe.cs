using System;
using System.Collections.Generic;
using System.IO;

namespace ZooBitSketch
{
    internal class Wardrobe<T> : AbstractPack<Clothes>
    {
        public List<Clothes> _clothes { get; private set; }
        public Wardrobe(int size) : base(size)
        {
            _clothes = new List<Clothes>();
        }
        sealed public override void Info()
        {
            Pack.Sort(delegate (Clothes x, Clothes y)
            {
                return x.CompareTo(y);
            });
            base.Info();
        }
        sealed protected override void WriteList()
        {
            base.WriteList();
            Console.WriteLine($"Amount of clothes you have is {Pack.Count}\n" +
                $"If you want to know anything about clothes, white number. For exit write \"exit.\"\n");
            for (int i = 0; i < Pack.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Pack[i].Name} {Pack[i].Rareness} {Pack[i].Phase}", Console.ForegroundColor = Pack[i].ChooseColor());
            }
        }
    }
}

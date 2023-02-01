using System;
using System.Collections.Generic;
using ZooBitSketch.Property.Actives;

namespace ZooBitSketch.Property.Decks
{
    internal class Wardrobe : AbstractDeck<Clothes>
    {
        public Wardrobe(int size) : base(size)
        {
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
                Console.WriteLine($"{i + 1} - {Pack[i].Name} {Pack[i].Rareness} {Pack[i].States.Power} ", Console.ForegroundColor = Pack[i].ChooseColor());
            }
        }
        sealed protected override void Remove(object newItem)
        {
            Clothes forRemoving = newItem as Clothes;
            if (forRemoving != null)
            {
                forRemoving.SacrificeMe -= Remove;
                Pack.Remove(forRemoving);
                Console.WriteLine(forRemoving.Info() + "\nwas removed");
            }
        }
    }
}

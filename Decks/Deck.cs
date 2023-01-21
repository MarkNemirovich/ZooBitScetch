using System;

namespace ZooBitSketch
{
    internal class Deck<T> : AbstractDeck<Card>
    {
        public Deck(int size) : base(size)
        {
        }
        sealed public override void Info()
        {
            Pack.Sort(delegate (Card x, Card y)
            {
                return x.CompareTo(y);
            });
            base.Info();
        }
        sealed protected override void WriteList()
        {
            base.WriteList();
            Console.WriteLine($"Amount of cards you have is {Pack.Count}\n" +
                $"If you want to know anything about cards, white number. For exit write \"exit.\"\n");
            for (int i = 0; i < Pack.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Pack[i].Name} {Pack[i].Rareness} {Pack[i].Quality} {Pack[i].States.Power }", Console.ForegroundColor = Pack[i].ChooseColor());
            }
        }
        sealed protected override void Remove(object newItem)
        {
            Card forRemoving = newItem as Card;
            if (forRemoving != null)
            {
                forRemoving.IWasSacrificed -= Remove;
                Pack.Remove(forRemoving);
                Console.WriteLine(forRemoving.Info() + "\nwas removed");
            }
        }
    }
}

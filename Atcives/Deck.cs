using System;

namespace ZooBitSketch
{
    internal class Deck<T> : AbstractPack<Card>
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
                Console.WriteLine($"{i + 1} - {Pack[i].Name} {Pack[i].Rareness} {Pack[i].Phase}", Console.ForegroundColor = Pack[i].ChooseColor());
            }
        }
    }
}

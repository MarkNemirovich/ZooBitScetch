using System;

namespace ZooBitSketch
{
    internal class Purse
    {
        public int Money { get; private set; }
        public int Diamonds { get; private set; }
        public int DNA { get; private set; }
        public Purse()
        {
            Money = 1000;
            Diamonds = 0;
            DNA = 0;
        }
        public void Info()
        {
            Console.WriteLine($"Money = {Money}\nDiamonds = {Diamonds}\nDNA = {DNA}\n\nPress any key for continue...");
            Console.ReadKey();
        }
        public void Spend(int pay)
        {
            Money -= pay;
        }
    }
}

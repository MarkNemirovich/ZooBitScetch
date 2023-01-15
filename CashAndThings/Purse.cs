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
            Diamonds = 100;
            DNA = 0;
        }
        public void Info()
        {
            Console.WriteLine($"Money = {Money}\nDiamonds = {Diamonds}\nDNA = {DNA}\n\nPress any key for continue...");
            Console.ReadKey();
        }
        public void Spend((int cost, Currency currency) pay, int cashBack)
        {
            switch (pay.currency)
            {
                case Currency.Money: Money -= pay.cost; break;
                case Currency.Diamonds: Diamonds -= pay.cost; break;
                case Currency.DNA: DNA -= pay.cost; break;
            }
            DNA += cashBack;
        }
    }
}

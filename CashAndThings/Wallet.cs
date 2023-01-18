using System;

namespace ZooBitSketch
{
    internal class Wallet
    {
        public int Money { get; private set; }
        public int Diamonds { get; private set; }
        public int DNA { get; private set; }
        public Wallet()
        {
            Money = 1000;
            Diamonds = 1000;
            DNA = 0;
        }
        public void Info()
        {
            Console.WriteLine($"Money = {Money}\nDiamonds = {Diamonds}\nDNA = {DNA}\n\nPress any key for continue...");
            Console.ReadKey();
        }
        public void Pay((int cost, Currency currency) pay)
        {
            switch (pay.currency)
            {
                case Currency.Money: Money -= pay.cost; break;
                case Currency.Diamonds: Diamonds -= pay.cost; break;
                case Currency.DNA: DNA -= pay.cost; break;
            }
        }
        public void DecayCharacter(Rareness rareness)
        {
            DNA += (int)Rareness.Ordinary / (int)rareness;
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class Wallet
    {
        public int Money { get; private set; }
        public int Diamond { get; private set; }
        public int DNA { get; private set; }
        public int Heart { get; private set; }
        public Wallet()
        {
            Money = 1000;
            Diamond = 1000;
            DNA = 0;
            Heart = 0;
        }
        public void Info()
        {
            Console.WriteLine($"Money = {Money}\nDiamonds = {Diamond}\nDNA = {DNA}\n\nPress any key for continue...");
            Console.ReadKey();
        }
        public void Pay((int cost, Currency currency) pay)
        {
            switch (pay.currency)
            {
                case Currency.Money: Money -= pay.cost; break;
                case Currency.Diamonds: Diamond -= pay.cost; break;
                case Currency.DNA: DNA -= pay.cost; break;
            }
        }
        public void DecayCharacter(Rareness rareness)
        {
            DNA += (int)Rareness.Ordinary / (int)rareness;
        }
    }
}
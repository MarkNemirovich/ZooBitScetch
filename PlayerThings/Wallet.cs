using System;
using System.Collections.Generic;

namespace ZooBitSketch.Player
{
    internal class Wallet : IPayable
    {
        private static readonly Lazy<Wallet> lazy = new Lazy<Wallet>(() => new Wallet());
        private Dictionary<Currency, int> Cash;
        private Wallet()
        {
            Cash = new Dictionary<Currency, int>();
            Cash.TryAdd(Currency.Money, 1000);
            Cash.TryAdd(Currency.Diamonds, 1000);
            Cash.TryAdd(Currency.DNA, 1000);
            Cash.TryAdd(Currency.Heart, 1000);
        }
        public static Wallet GetInstance()
        {
            return lazy.Value;
        }
        public void Info()
        {
            string data = string.Empty;
            foreach (var pair in Cash)
            {
                data += $"{pair.Key.ToString()} = {pair.Value}\n";
            }
            Console.WriteLine($"{data}Press any key for continue...");
            Console.ReadKey();
        }
        public int CheckAmount(Currency currency)
        {
            Cash.TryGetValue(currency, out int amount);
            return amount;
        }
        public bool Pay(Currency currency, int cost)
        {
            if(Cash.TryGetValue(currency, out int cashAmount))
            {
                if (cashAmount >= cost)
                {
                    Cash[currency] -= cost;
                    return true;
                }
            }
            return false;
        }
        public void DecayCharacter(Rareness rareness)
        {
            if (Cash.TryGetValue(Currency.DNA, out int DNAAmount))
                Cash[Currency.DNA] += (int)Rareness.Ordinary / (int)rareness;
        }
    }
}
using System;
using System.Collections.Generic;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.PlayerThings
{
    internal class Wallet : IPayable
    {
        private static readonly Lazy<Wallet> lazy = new Lazy<Wallet>(() => new Wallet());
        private Dictionary<Currency, int> cash;
        private Wallet()
        {
            cash = new Dictionary<Currency, int>();
            cash.TryAdd(Currency.Money, 1000);
            cash.TryAdd(Currency.Diamonds, 1000);
            cash.TryAdd(Currency.DNA, 1000);
            cash.TryAdd(Currency.Heart, 1000);
        }
        public static Wallet GetInstance()
        {
            return lazy.Value;
        }
        public void Info()
        {
            string data = string.Empty;
            foreach (var pair in cash)
            {
                data += $"{pair.Key.ToString()} = {pair.Value}\n";
            }
            Console.WriteLine($"{data}Press any key for continue...");
            Console.ReadKey();
        }
        public int CheckAmount(Currency currency)
        {
            cash.TryGetValue(currency, out int amount);
            return amount;
        }
        public bool Pay(Currency currency, int cost)
        {
            if(cash.TryGetValue(currency, out int cashAmount))
            {
                if (cashAmount >= cost)
                {
                    cash[currency] -= cost;
                    return true;
                }
            }
            return false;
        }
        public void DecayCharacter(Rareness rareness)
        {
            if (cash.TryGetValue(Currency.DNA, out int DNAAmount))
                cash[Currency.DNA] += (int)Rareness.Ordinary / (int)rareness;
        }
    }
}
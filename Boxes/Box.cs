using System;
using System.Collections.Generic;
using System.Linq;
using ZooBitSketch;
using ZooBitSketch.Player;
using ZooBitSketch.PlayerThings;

namespace ZooBitSketch
{
    internal abstract class Box
    {
        public BoxSize Size { get; private set; }
        public readonly string Name;
        private readonly int price;
        private readonly Currency currency;
        protected readonly Random rand = new Random();
        public Box(int price, Currency currency, BoxSize size)
        {
            this.price = price;
            this.currency = currency;
            Size = size;
            Name = $"{size} {currency} box";
        }
        public (int, Currency) Cost() => (price, currency);
        public string Info(int playerLvl)
        {
            return $"\nName = {Name}\nPrice = {price} {currency.ToString().ToLower()}\nCards inside = {(int)Size}\n{ChancesDescription(playerLvl)}\n";
        }
        public bool TryOpen(ICustomer customer, out Active[] actives)
        {
            actives = null;
            if (customer.Purchase(currency, price))
            {
                List<Active> content = new List<Active>();
                for (int i = 0; i < (int)Size; i++)
                {
                    Rareness rareness = GetRareness(customer.GetLvl);
                    Active[] array = GetActiveArray(rareness);
                    content.Add(GetActive(array.ToList()));
                }
                actives = content.ToArray();
                return true;
            }
            return false;
        }
        protected abstract double RarenessProbability(Rareness rareness, int playerLvl);
        protected virtual double TypeProbability(string typeName)
        {
            if (typeName == typeof(Character).ToString())
                return 25;
            else
                return 25 + 37.5;
        }
        private Rareness GetRareness(int playerLvl)
        {
            double dice = rand.NextDouble() * 100;
            for (Rareness i = Rareness.Legendary; i <= Rareness.Ordinary; i++)
            {
                if (dice < RarenessProbability(i, playerLvl))
                {
                    return i;
                }
            }
            return Rareness.Ordinary;
        }
        private Active[] GetActiveArray(Rareness rareness)
        {
            Active[] actives = null;
            double dice = rand.NextDouble() * 100;
            if (dice < TypeProbability(typeof(Character).ToString()))
            {
                var array = new CharactersGallery(rareness);
                actives = array.CurrentPack;
            }
            else if (dice < TypeProbability(typeof(Clothes).ToString()))
            {
                var array = new ClothesGallery(rareness);
                actives = array.CurrentPack;
            }
            else
            {
                var array = new CardsGallery(rareness);
                actives = array.CurrentPack;
            }
            return actives;
        }
        protected virtual Active GetActive(List<Active> actves)
        {
            int dice = rand.Next(0, actves.Count);
            return actves[dice];
        }
        private string ChancesDescription(int playerLvl)
        {
            string text = "For your lvl in this box you can get:\n";
            foreach (Rareness rareness in Enum.GetValues(typeof(Rareness)))
                text += $"{rareness.ToString()} active at {RarenessProbability(rareness, playerLvl):f2} %\n";
            return text;
        }
    }
}

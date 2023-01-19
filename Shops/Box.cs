using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection.Metadata;
using System.Runtime.ExceptionServices;
using System.Text;

namespace ZooBitSketch
{
    internal abstract class Box
    {
        public string Name { get; private set; }
        public BoxSize Size { get; private set; }
        protected double[] ActiveChances;
        private int _cost;
        private Currency _currency;
        private readonly Random rand;
        public Box(int cost, Currency currency, BoxSize size)
        {
            _cost = cost;
            _currency = currency;
            Size = size;
            Name = $"{size} {currency} box";
            rand = new Random();
        }
        public (int, Currency) Cost() => (_cost, _currency);
        public string Info(int playerLvl)
        {
            return $"\nName = {Name}\nCost = {_cost} money\nCards inside = {(int)Size}\n{ChancesDescription(playerLvl)}\n";
        }
        public bool TryOpen(Player customer, out Active[] actives)
        {
            actives = null;
            switch (_currency)
            {
                case Currency.Money:
                    if (customer.Wallet.Money >= _cost)
                        break;
                    else
                        return false;
                case Currency.Diamonds:
                    if (customer.Wallet.Diamonds >= _cost)
                        break;
                    else
                        return false;
                default: 
                    return false;
            }
            List<Active> content = new List<Active>();
            for (int i = 0; i < (int)Size; i++)
            {
                Rareness rareness = GetRareness(customer.Lvl);
                Active[] array = GetActiveArray(rareness);
                content.Add(GetActive(array));
            }
            actives = content.ToArray();
            return true;
        }
        protected Rareness GetRareness(int playerLvl)
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
        protected Active[] GetActiveArray(Rareness rareness)
        {
            Active[] actives = null;
            int dice = rand.Next(0, 8);
            switch (dice)
            {
                case 0:
                case 1:
                case 2:
                    {
                        var array = new CardsGallery(rareness);
                        actives = array.CurrentList;
                        break;
                    }
                case 3:
                case 4:
                case 5:
                    {
                        var array = new ClothesGallery(rareness);
                        actives = array.CurrentList;
                        break;
                    }
                case 6:
                case 7:
                    {
                        var array = new CharactersGallery(rareness);
                        actives = array.CurrentList;
                        break;
                    }
            }
            return actives;
        }
        protected virtual Active GetActive(Active[] actves)
        {
            int dice = rand.Next(0, actves.Length);
            return actves[dice];
        }
        protected string ChancesDescription(int playerLvl)
        {
            string text = "For your lvl in this box you can get:\n";
            foreach (Rareness rareness in Enum.GetValues(typeof(Rareness)))
                text += $"{rareness.ToString()} active at {RarenessProbability(rareness, playerLvl):f2} %\n";
                return text;
        }
        protected double RarenessProbability(Rareness rareness, int playerLvl)
        {
            double maxChance = 0;
            if (_currency == Currency.Money)
                switch (rareness)
                {
                    case Rareness.Ordinary:
                        maxChance = 600 - 2 * playerLvl;
                        break;
                    case Rareness.Rare:
                        maxChance = 300 - playerLvl;
                        break;
                    case Rareness.Elite:
                        maxChance = 90;
                        break;
                    case Rareness.Epic:
                        maxChance = 10 + 2 * playerLvl;
                        break;
                    default:
                        maxChance = playerLvl;
                        break;
                }
            else
            {
                switch (rareness)
                {
                    case Rareness.Ordinary:
                        maxChance = 550 - 2 * playerLvl;
                        break;
                    case Rareness.Rare:
                        maxChance = 250 - playerLvl;
                        break;
                    case Rareness.Elite:
                        maxChance = 150;
                        break;
                    case Rareness.Epic:
                        maxChance = 49 + playerLvl;
                        break;
                    case Rareness.Legendary:
                        maxChance = 1 + 2 * playerLvl;
                        break;
                }
            }
            return maxChance/10;
        }
    }
}

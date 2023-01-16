using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace ZooBitSketch
{
    internal abstract class Box
    {
        public string Name { get; private set; }
        public BoxSize Size { get; private set; }
        protected double[] ActiveChances;
        private CharactersGallery _characters;
        private ClothesGallery _clothes;
        private CardsGallery _cards;
        private Active[] _allActives;
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
        public void Open()
        {
            CalculateChances();
        }
        protected void CalculateChances()
        {
            List<Active> active = new List<Active>();
            

        }


        public string ChancesDescription(int playerLvl)
        {            
            StringBuilder sb = new StringBuilder();
            double[] chances = CalculateRareness(playerLvl);
            sb.Append($"Common = {chances[0]}%\n");
            sb.Append($"Rare = {chances[1]}%\n");
            sb.Append($"Elite = {chances[2]}%\n");
            sb.Append($"Epic = {chances[3]}%\n");
            sb.Append($"Legendary = {chances[4]}%\n");
            return sb.ToString();
        }
        public Rareness GetRareness(int playerLvl)
        {
            double[] chances = CalculateRareness(playerLvl);
            double d = rand.NextDouble()*100;
            if (d < chances[chances.Length-1])
                return Rareness.Legendary;
            if (d < chances[chances.Length - 2])
                return Rareness.Epic;
            if (d < chances[chances.Length - 3])
                return Rareness.Elite;
            if (d < chances[chances.Length - 4])
                return Rareness.Rare;
            return Rareness.Ordinary;
        }
        protected virtual double[] CalculateRareness(int playerLvl)
        {
            double common = 200 - playerLvl * ((int)_currency + 1) - 10 * (int)_currency;
            double rare = common / 2 + playerLvl * ((int)_currency + 1) - 20 * (int)_currency;
            double elite = playerLvl * ((int)_currency + 10) + 20 * (int)_currency;
            double epic = elite / (200 - playerLvl) + 10 * (int)_currency;
            double legendary = epic * ((int)_currency) / 100;
            double total = common + rare + elite + epic + legendary;
            double[] chances = new double[5];
            chances[0] = Math.Round(100.0 * common / total, 2);
            chances[1] = Math.Round(100.0 * rare / total, 2);
            chances[2] = Math.Round(100.0 * elite / total, 2);
            chances[3] = Math.Round(100.0 * epic / total, 2);
            chances[4] = Math.Round(100.0 * legendary / total, 2);
            return chances;
        }
    }
}

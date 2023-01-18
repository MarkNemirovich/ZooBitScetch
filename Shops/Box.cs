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
        public Active[] Open()
        {
            // CalculateAllChances();
            return SmartChancesCalculation();
        }
        protected Active[] SmartChancesCalculation()
        {
            List<Active> content = new List<Active>();
            for (int i = 0; i < (int)Size; i++)
            {
                Rareness rareness;
                int dice = rand.Next(0, 100);
                if (_currency == Currency.Money)
                    dice = (int)(dice*0.9);
                if (dice < 54)
                    rareness = Rareness.Ordinary;
                else if (dice < 79)
                    rareness = Rareness.Rare;
                else if (dice < 94)
                    rareness = Rareness.Elite;
                else if (dice < 99)
                    rareness = Rareness.Epic;
                else
                    rareness = Rareness.Legendary;
                dice = rand.Next(0, 8);
                switch (dice)
                {
                    case 0:
                    case 1:
                    case 2:
                        {
                            CardsGallery array = new CardsGallery(rareness);
                            dice = rand.Next(0, array.CurrentList.Length);
                            content.Add((Active)array.CurrentList[dice]);
                            break;
                        }
                    case 3:
                    case 4:
                    case 5:
                        {
                            ClothesGallery array = new ClothesGallery(rareness);
                            dice = rand.Next(0, array.CurrentList.Length);
                            content.Add((Active)array.CurrentList[dice]);
                            break;
                        }
                    case 6:
                    case 7:
                        {
                            CharactersGallery array = new CharactersGallery(rareness);
                            dice = rand.Next(0, array.CurrentList.Length);
                            content.Add((Active)array.CurrentList[dice]);
                            break;
                        }
                }
            }
            return content.ToArray();
        }
        protected void CalculateAllChances() // all things chances' calculation
        {
            List<Active> allActives = new List<Active>();
            double total = 0;
            foreach (Rareness rareness in Enum.GetValues(typeof(Rareness)))
            {
                CharactersGallery _characters = new CharactersGallery(rareness);
                ClothesGallery _clothes = new ClothesGallery(rareness);
                CardsGallery _cards = new CardsGallery(rareness);
                var ch = _characters.FullCardList();
                total += ch.Count * Math.Pow((int)rareness, 5);
                var cl = _clothes.FullCardList();
                total += ch.Count * Math.Pow((int)rareness, 5);
                var ca = _cards.FullCardList();
                total += ch.Count * Math.Pow((int)rareness, 5);
                allActives.AddRange(ch);
                allActives.AddRange(cl);
                allActives.AddRange(ca);
            }
            List<(Active active, double chance)> probability = new List<(Active, double)>();
            double sum = 0;
            for (int i = 0; i < allActives.Count; i++)
            {
                var amount = Math.Pow((double)allActives[i].Rareness, 5) / total * 100;
                probability.Add((allActives[i], Math.Round(amount,3)));
                sum += Math.Round(amount, 3);
                Console.WriteLine($"{i+1} - {probability[i].active.Name} with {probability[i].chance}% chance");
            }
            Console.WriteLine("total " + total);
            Console.WriteLine("sum " + sum);
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

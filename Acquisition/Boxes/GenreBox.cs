using System;
using System.Collections.Generic;
using System.Linq;
using ZooBitSketch.Enums;
using ZooBitSketch.Property.Actives;

namespace ZooBitSketch.Acquisition.Boxes
{
    internal class GenreBox : Box
    {
        public Genre DoubleChanceGenre { get; private set; }
        public GenreBox(int cost, Currency currency, BoxSize size, Genre doubleChanceGenre) : base(cost, currency, size)
        {
            DoubleChanceGenre = doubleChanceGenre;
        }
        protected override double RarenessProbability(Rareness rareness, int playerLvl)
        {
            double maxChance = 0;
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
            return maxChance / 10;
        }
        sealed protected override Active GetActive(List<Active> actves)
        {
            int length = actves.Count;
            for (int i = 0; i < length; i++)
                if (actves[i].Genre == DoubleChanceGenre)
                {
                    actves.Add(actves[i]);
                    actves.Add(actves[i]);
                    actves.Add(actves[i]);
                    actves.Add(actves[i]);
                    actves.Add(actves[i]);
                }
            int dice = rand.Next(0, actves.Count);
            return actves[dice];
        }
    }
}
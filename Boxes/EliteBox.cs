using System;

namespace ZooBitSketch
{
    internal class EliteBox : Box
    {
        public EliteBox(int cost, Currency currency, BoxSize size) : base(cost, currency, size) { }
        sealed protected override double RarenessProbability(Rareness rareness, int playerLvl)
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
    }
}

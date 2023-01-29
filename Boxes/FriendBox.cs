using System;

namespace ZooBitSketch
{
    internal class FriendBox : Box
    {
        public FriendBox(int cost, Currency currency, BoxSize size) : base(cost, currency, size)
        {
        }
        protected override double RarenessProbability(Rareness rareness, int playerLvl)
        {
            double maxChance = 0;
            switch (rareness)
            {
                case Rareness.Ordinary:
                    maxChance = 800 - 2 * playerLvl;
                    break;
                case Rareness.Rare:
                    maxChance = 200 - playerLvl;
                    break;
                case Rareness.Elite:
                    maxChance = 2 * playerLvl;
                    break;
                case Rareness.Epic:
                    maxChance = playerLvl;
                    break;
                default:
                    maxChance = 0;
                    break;
            }
            return maxChance / 10;
        }
    }
}

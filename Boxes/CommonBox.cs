using System;

namespace ZooBitSketch
{
    internal class CommonBox : Box
    {
        public CommonBox(int cost, Currency currency, BoxSize size) : base(cost, currency, size)
        {
        }
        protected override double RarenessProbability(Rareness rareness, int playerLvl)
        {
            double maxChance = 0;
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
            return maxChance / 10;
        }
        sealed protected override bool CheckMoney(Wallet wallet)
        {
            var cost = Cost();
            return wallet.Money >= cost.Item1;
        }
    }
}

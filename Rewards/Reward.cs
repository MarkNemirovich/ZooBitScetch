using System;
using System.Collections.Generic;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Rewards
{
    internal class Reward
    {
        protected readonly Dictionary<Currency, int> currency;
        public Reward(Dictionary<Currency, int> reward)
        {
            currency = reward;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Rewards
{
    internal class StageReward : Reward
    {
        private readonly int experience;
        public StageReward(Dictionary<Currency, int> reward, int exp) : base(reward)
        {
            experience = exp;
        }
    }
}

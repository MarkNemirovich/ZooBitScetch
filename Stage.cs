using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ZooBitSketch.Enums;
using ZooBitSketch.Rewards;

namespace ZooBitSketch
{
    internal class Stage
    {
        public event Action StageStarted;
        public event Action StageComplited;
        public event Action StageCleared;

        public readonly string Name;
        public readonly string TermsDescription;
        public readonly int TeamSize;
        public readonly int DeckSize;
        public readonly int EuphoriaGoal;
        public readonly Genre benefitGenre;
        public readonly Genre adverseGenre;
        public readonly Predicate<HashSet<Role>> Restriction;
        public readonly Predicate<(Conditions, int)> Bonus;
        public readonly StageReward Reward;
        public int Stars { get; private set; }

        public Stage(string name, string description, int teamSize, int deckSize, int euphoriaAmount, Genre benefit, Genre adverse,
            Predicate<HashSet<Role>> restriction, Predicate<(Conditions, int)> bonus, StageReward rewards)
        {
            Name = name;
            TermsDescription = description;
            TeamSize = teamSize;
            DeckSize = deckSize;
            EuphoriaGoal = euphoriaAmount;
            Stars = -1;
            benefitGenre = benefit;
            adverseGenre = adverse;
            Restriction = restriction;
            Bonus = bonus;
            Reward = rewards;
        }
        public void ChangeEnableMode(Terms term)
        {
            if (term == Terms.Open)
            {
                Stars = 0;
                return;
            }
            if ((int)term > Stars)
            {
                if (Stars == 0)
                    StageComplited?.Invoke();
                Stars = (int)term;
            }
            StageCleared?.Invoke();
        }
        public string Info()
        {
            string text = $"{Name,-30}";
            if (Stars < 0)
                text += "is not available yet";
            if (Stars < 0)
                text += $"is not completed yet";
            else
                text += $"is completed on {Stars} stars";
            return text;
        }
    }
}

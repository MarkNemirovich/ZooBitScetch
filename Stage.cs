using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using ZooBitSketch.Enums;

namespace ZooBitSketch
{
    internal class Stage
    {
        private const int CARDS_LIMIT = 15;
        public readonly string Name;
        public int TeamSize { get; private set; }
        public int DeckSize { get; private set; }
        public int Stars { get; private set; }
        public int EuphoriaAmount { get; private set; }
        public Genre benefitGenre;
        public Genre adverseGenre;
        private bool isAvaliable;
        public Predicate<HashSet<Role>> RestrictedTerm { get; private set; }
        public Predicate<(Conditions, int)> BonusTerm { get; private set; }

        public Stage(string name, int teamSize, int deckSize, int euphoriaAmount, Genre benefit, Genre adverse, Predicate<HashSet<Role>> restricted, Predicate<(Conditions, int)> bonus)
        {
            Name = name;
            TeamSize = teamSize;
            DeckSize = deckSize;
            Stars = 0;
            EuphoriaAmount = euphoriaAmount;
            benefitGenre = benefit;
            adverseGenre = adverse;
            RestrictedTerm = restricted;
            BonusTerm = bonus;
        }
        public void ChangeEnableMode(Terms term)
        {
            if ((int)term > Stars)
                Stars = (int)term;
            isAvaliable = (Stars == (int)Terms.Failed || Stars == (int)Terms.Bonus + (int)Terms.Bonus);
        }
    }
}

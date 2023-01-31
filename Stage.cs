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
        public int Stars { get; private set; }
        public Genre benefitGenre;
        public Genre adverseGenre;
        private bool isAvaliable;
        public Predicate<HashSet<Role>> restrictedTerm { get; private set; }
        public Predicate<Condition> bonusTerm { get; private set; }

        public Stage(string name, Genre benefit, Genre adverse, Predicate<HashSet<Role>> restricted, Predicate<Condition> bonus)
        {
            Name = name;
            Stars = 0;
            benefitGenre = benefit;
            adverseGenre = adverse;
            restrictedTerm = restricted;
            bonusTerm = bonus;
        }
        public void ChangeEnableMode(Terms term)
        {
            if ((int)term > Stars)
                Stars = (int)term;
            isAvaliable = (Stars == (int)Terms.Failed || Stars == (int)Terms.Bonus + (int)Terms.Bonus);
        }
    }
}

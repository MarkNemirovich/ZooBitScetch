using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives.Cards
{
    internal class BonusCard : Card
    {
        public BonusCard(string name, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states) { }
    }
}

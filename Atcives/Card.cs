using System;

namespace ZooBitSketch
{
    internal class Card : Active
    {
        private CardType _type;
        public Card(string name, CardType type, Phase phase, Rareness rareness, Role role, Genre genre, States states)
            : base(name, phase, rareness, role, genre, states)
        {
            _type = type;
        }
    }
}

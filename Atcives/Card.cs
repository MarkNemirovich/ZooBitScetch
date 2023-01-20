using System;

namespace ZooBitSketch
{
    internal class Card : Active
    {
        private CardType _type;
        public Quality Quality { get; private set; }
        public Card(string name, CardType type, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            Quality = Quality.Bronse;
            _type = type;
        }
        sealed public override void Evolve()
        {
            Quality++;
            States.Evolve(1.5);
            States.CalculatePower();
        }
    }
}

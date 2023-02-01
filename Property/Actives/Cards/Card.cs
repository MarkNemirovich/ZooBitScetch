using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives.Cards
{
    internal class Card : Active
    {
        public Quality Quality { get; private set; }
        public Card(string name, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            Quality = Quality.Bronse;
        }
        sealed public override void Evolve()
        {
            Quality++;
            States.Evolve(1.5);
            base.Evolve();
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class Clothes : Active
    {
        private ClothesType _type;
        public int _enhanceLevel { get; private set; }
        public int _enhanceCost { get; private set; }
        public Clothes(string name, ClothesType type, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            _type = type;
            _enhanceLevel = 0;
            _enhanceCost = 100;
        }
        sealed public override void Evolve()
        {
            _enhanceLevel++;
            _enhanceCost += _enhanceCost;
            States.Evolve(1.1);
            States.CalculatePower();
        }
    }
}

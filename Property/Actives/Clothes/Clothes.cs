using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives.Clothes
{
    internal class Clothes : Active
    {
        public int EnhanceLevel { get; private set; }
        public int EnhanceCost { get; private set; }
        public Clothes(string name, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            EnhanceLevel = 0;
            EnhanceCost = 10 * (int)Rareness.Ordinary / (int)rareness;
        }
        sealed public override void Evolve()
        {
            EnhanceLevel++;
            EnhanceCost += EnhanceCost;
            States.Evolve(1.1);
            base.Evolve();
        }
        public int CalculateEnhanceCost()
        {
            return (int)Rareness.Ordinary / (int)Rareness * (EnhanceLevel + 1);
        }
    }
}

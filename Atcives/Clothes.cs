using System;

namespace ZooBitSketch
{
    internal class Clothes : Active
    {
        private ClothesType _type;
        public Clothes(string name, ClothesType type, Phase phase, Rareness rareness, Role role, Genre genre, States states)
            : base(name, phase, rareness, role, genre, states)
        {
            _type = type;
        }
    }
}

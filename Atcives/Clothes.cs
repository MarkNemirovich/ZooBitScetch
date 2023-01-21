using System;

namespace ZooBitSketch
{
    internal class Clothes : Active
    {
        private ClothesType _type;
        public int EnhanceLevel { get; private set; }
        public int EnhanceCost { get; private set; }
        public Clothes(string name, ClothesType type, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            _type = type;
            EnhanceLevel = 0;
            EnhanceCost = 100;
        }
        public override int GetHashCode()
        {
            byte typeSum = 0;
            byte nameSum = 0;
            foreach (char letter in this.GetType().Name)
                typeSum += (byte)letter;
            foreach (char letter in Name)
                nameSum += (byte)letter;
            return (typeSum << 24) | ((byte)EnhanceLevel << 20) | ((byte)Rareness << 16) | ((byte)Role << 12) | ((byte)Genre << 8) | (nameSum);
        }
        sealed public override void Evolve()
        {
            EnhanceLevel++;
            EnhanceCost += EnhanceCost;
            States.Evolve(1.1);
            States.CalculatePower();
        }
        sealed public override int CompareTo(Active another)
        {
            Clothes clothes = another as Clothes;
            int first = _type.CompareTo(clothes._type);
            if (first != 0) { return first; }
            first = Rareness.CompareTo(clothes.Rareness);
            if (first != 0) { return first; }
            first = -EnhanceLevel.CompareTo(clothes.EnhanceLevel);
            if (first != 0) { return first; }
            else return -States.Power.CompareTo(clothes.States.Power);
        }
    }
}

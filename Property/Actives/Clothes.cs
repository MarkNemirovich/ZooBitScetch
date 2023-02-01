using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives
{
    internal class Clothes : Active
    {
        public readonly ClothesType PartType;
        public int EnhanceLevel { get; private set; }
        public int EnhanceCost { get; private set; }
        public Clothes(string name, ClothesType type, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            PartType = type;
            EnhanceLevel = 0;
            EnhanceCost = 10 * (int)Rareness.Ordinary / (int)rareness;
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
            int first = PartType.CompareTo(clothes.PartType);
            if (first != 0) { return first; }
            first = Rareness.CompareTo(clothes.Rareness);
            if (first != 0) { return first; }
            first = -EnhanceLevel.CompareTo(clothes.EnhanceLevel);
            if (first != 0) { return first; }
            else return -States.Power.CompareTo(clothes.States.Power);
        }
        public int CalculateEnhanceCost()
        {
            return (int)Rareness.Ordinary / (int)Rareness * (EnhanceLevel+1);
        }
    }
}

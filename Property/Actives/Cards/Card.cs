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
        sealed public override int GetHashCode()
        {
            byte typeSum = 0;
            byte nameSum = 0;
            foreach (char letter in GetType().Name)
                typeSum += (byte)letter;
            foreach (char letter in Name)
                nameSum += (byte)letter;
            return typeSum << 24 | (byte)Quality << 20 | (byte)Rareness << 16 | (byte)Role << 12 | (byte)Genre << 8 | nameSum;
        }
        sealed public override int CompareTo(Active another)
        {
            return GetHashCode().CompareTo(another.GetHashCode());
        }
        sealed public override void Evolve()
        {
            Quality++;
            States.Evolve(1.5);
            States.CalculatePower();
        }
    }
}

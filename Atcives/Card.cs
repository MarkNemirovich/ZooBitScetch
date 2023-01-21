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
        public override int GetHashCode()
        {
            byte typeSum = 0;
            byte nameSum = 0;
            foreach (char letter in this.GetType().Name)
                typeSum += (byte)letter;
            foreach (char letter in Name)
                nameSum += (byte)letter;
            return (typeSum << 24) | ((byte)Quality << 20) | ((byte)Rareness << 16) | ((byte)Role << 12) | ((byte)Genre << 8) | (nameSum);
        }
        sealed public override void Evolve()
        {
            Quality++;
            States.Evolve(1.5);
            States.CalculatePower();
        }
    }
}

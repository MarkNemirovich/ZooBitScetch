using System;

namespace ZooBitSketch
{
    internal class Card : Active
    {
        private readonly CardType _type;
        public Quality Quality { get; private set; }
        public Card(string name, CardType type, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            Quality = Quality.Bronse;
            _type = type;
        }
        sealed public override int GetHashCode()
        {
            byte typeSum = 0;
            byte nameSum = 0;
            foreach (char letter in this.GetType().Name)
                typeSum += (byte)letter;
            foreach (char letter in Name)
                nameSum += (byte)letter;
            return (typeSum << 24) | ((byte)Quality << 20) | ((byte)Rareness << 16) | ((byte)Role << 12) | ((byte)Genre << 8) | (nameSum);
        }
        sealed public override int CompareTo(Active another)
        {
            Card card = another as Card;
            int first = _type.CompareTo(card._type);
            if (first != 0) { return first; }
            first = Rareness.CompareTo(card.Rareness);
            if (first != 0) { return first; }
            first = -Quality.CompareTo(card.Quality);
            if (first != 0) { return first; }
            else return -States.Power.CompareTo(card.States.Power);
        }
        sealed public override void Evolve()
        {
            Quality++;
            States.Evolve(1.5);
            States.CalculatePower();
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class Character : Active
    {
        public Phase Phase { get; private set; }
        public int Copies => _copies;
        private int _copies;
        public Character(string name, Phase phase, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            _copies = 0;
            Phase = phase;
        }
        public void AddCopy()
        {
            _copies++;
            if (_copies >= (int)Rareness)
            {
                Evolve();
                _copies = 0;
            }
        }
        public override int GetHashCode()
        {
            byte typeSum = 0;
            byte nameSum = 0;
            foreach (char letter in this.GetType().Name)
                typeSum += (byte)letter;
            foreach (char letter in Name)
                nameSum += (byte)letter;
            return (typeSum << 24) | ((byte)Phase << 20) | ((byte)Rareness << 16) | ((byte)Role << 12) | ((byte)Genre << 8) | (nameSum);
        }
        sealed public override int CompareTo(Active another)
        {
            Character character = (another as Character);
            int first = Rareness.CompareTo(character.Rareness);
            if (first != 0)
                return first;
            else
                first = -Phase.CompareTo(character.Phase);
            if (first != 0) 
                return first;
            else return -States.Power.CompareTo(another.States.Power);
        }
        sealed public override void Evolve()
        {
            Phase++;
            States.Evolve(2 + (double)Phase / 10);
            States.CalculatePower();
        }
        public override string Info()
        {
            string text = $"\nType: {this.GetType().Name,-10}\tName: {Name,-10}\tGUID: {Convert.ToString(Guid, 2)}\n" +
                $"Rareness: {Rareness.ToString(),-10}Phase: {Phase.ToString(),-10}Class: {Role.ToString(),-10}Genre: {Genre.ToString()}\n" +
                $"{States.Info()}";
            return (text);
        }
    }
}

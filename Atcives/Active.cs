using System;
using System.Runtime.CompilerServices;

namespace ZooBitSketch
{
    internal abstract class Active : IComparable<Active>
    {
        public int Guid { get; private set; }
        public string Name { get; private set; }
        public States States { get; private set; }
        public readonly Rareness Rareness;
        public readonly Role Role;
        public readonly Genre Genre;
        public event Action<object> IWasSacrificed;
        protected Active(string name, Rareness rareness, Role role, Genre genre, States states)
        {
            Name = name;
            Rareness = rareness;
            Role = role;
            Genre = genre;
            States = states;
            Guid = GetHashCode();
        }
        public int GetTypeCode(Type t)
        {
            byte typeSum = 0;
            foreach (char letter in t.Name)
                typeSum += (byte)letter;
            return typeSum;
        }
        public override int GetHashCode()
        {
            byte typeSum = 0;
            byte nameSum = 0;
            foreach (char letter in this.GetType().Name)
                typeSum += (byte)letter;
            foreach (char letter in Name)
                nameSum += (byte)letter;
            return (typeSum << 20) | ((byte)Rareness << 16) | ((byte)Role << 12) | ((byte)Genre << 8) | (nameSum);
        }
        public ConsoleColor ChooseColor()
        {
            switch (Rareness)
            {
                case Rareness.Ordinary: return ConsoleColor.White;
                case Rareness.Rare: return ConsoleColor.Green;
                case Rareness.Elite: return ConsoleColor.Blue;
                case Rareness.Epic: return ConsoleColor.Cyan;
                case Rareness.Legendary: return ConsoleColor.Yellow;
                default: return ConsoleColor.White;
            }
        }
        public virtual void Evolve()
        {
            States.Evolve(1);
            States.CalculatePower();
        }
        public virtual int CompareTo(Active another)
        {
            int first = Rareness.CompareTo(another.Rareness);
            if (first != 0) { return first; }
            else return -States.Power.CompareTo(another.States.Power);
        }
        public virtual string Info()
        {
            string text =$"\nType: {this.GetType().Name,-10}\tName: {Name, -10}\tGUID: {Convert.ToString(Guid,2)}\n" +
                $"Rareness: {Rareness.ToString(),-10}Class: {Role.ToString(),-10}Genre: {Genre.ToString()}\n" +
                $"{States.Info()}";
            return (text);
        }
        public virtual void Sacrifice()
        {
            IWasSacrificed?.Invoke((object)this);
        }
    }
}

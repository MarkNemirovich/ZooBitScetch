using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives
{
    internal abstract class Active : IComparable<Active>
    {
        public long GUID { get; private set; }
        public string Name { get; private set; }
        public States States { get; private set; }
        public readonly Rareness Rareness;
        public readonly Role Role;
        public readonly Genre Genre;

        public event Action<object> SacrificeMe;

        protected Active(string name, Rareness rareness, Role role, Genre genre, States states)
        {
            Name = name;
            Rareness = rareness;
            Role = role;
            Genre = genre;
            States = states;
            GUID = GetGUID();
        }
        public virtual long GetGUID()
        {
            long typeSum = 0;
            long nameSum = 0;
            foreach (char letter in this.GetType().Name)
                typeSum += (long)letter;
            foreach (char letter in Name)
                nameSum += (long)letter;
            return (typeSum << 24) + ((long)Rareness << 16) + ((long)Role << 12) + ((long)Genre << 8) + (nameSum);
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
            GUID = GetGUID();
        }
        public int CompareTo(Active another)
        {
            return GUID.CompareTo(another.GUID);
        }
        public virtual string Info()
        {
            string text =$"\nType: {this.GetType().Name,-10}\tName: {Name, -10}\tGUID: {Convert.ToString(GUID,2)}\n" +
                $"Rareness: {Rareness.ToString(),-10}Class: {Role.ToString(),-10}Genre: {Genre.ToString()}\n" +
                $"{States.Info()}";
            return (text);
        }
        public void Sacrifice()
        {
            SacrificeMe?.Invoke((object)this);
        }
    }
}

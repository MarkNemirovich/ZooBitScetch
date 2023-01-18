using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Security.Claims;
using System.Xml.Linq;

namespace ZooBitSketch
{
    internal abstract class Active : IComparable<Active>
    {
        public int Guid { get; private set; }
        public string Name { get; private set; }
        public States States { get; private set; }
        public Phase Phase { get; private set; }
        public readonly Rareness Rareness;
        public readonly Role Role;
        public readonly Genre Genre;
        protected Active(string name, Phase phase, Rareness rareness, Role role, Genre genre, States states)
        {
            Name = name;
            Phase = phase;
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
            Phase++;
            States.Evolve(2 + (double)Phase/10);
            States.CalculatePower();
        }
        public int CompareTo(Active another)
        {
            int first = Rareness.CompareTo(another.Rareness);
            if (first != 0) { return first; }
            else return -Phase.CompareTo(another.Phase);
        }
        public string Info()
        {
            string text =$"\nName: {Name, -10}\nGUID: {Convert.ToString(Guid,2)}\n" +
                $"Rareness: {Rareness.ToString(),-10}Phase: {Phase.ToString(),-10}Class: {Role.ToString(),-10}Genre: {Genre.ToString()}\n" +
                $"{States.Info()}";
            return (text);
        }
    }
}

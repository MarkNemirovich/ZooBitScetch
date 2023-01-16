using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Claims;
using System.Xml.Linq;

namespace ZooBitSketch
{
    internal abstract class Active : IComparable<Active>
    {
        public string Name { get; private set; }
        public States States { get; private set; }
        public Phase Phase { get; private set; }
        public readonly Rareness Rareness;
        public readonly Class Class;
        public readonly Genre Genre;
        protected Active(string name, Phase phase, Rareness rareness, Class @class, Genre genre, States states) 
        {
            Name = name;
            Phase = phase;
            Rareness = rareness;
            Class = @class;
            Genre = genre;
            States = states;
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
            string text =$"\nName: {Name}\n" +
                $"Rareness: {Rareness.ToString(),-10}Phase: {Phase.ToString(),-10}Class: {Class.ToString(),-10}Genre: {Genre.ToString()}\n" +
                $"{States.Info()}";
            return (text);
        }
    }
}

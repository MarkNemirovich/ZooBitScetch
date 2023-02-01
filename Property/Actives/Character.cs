using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives
{
    internal class Character : Active
    {
        public Phase Phase { get; private set; }
        public int Copies => copies;
        private int copies;
        public Character(string name, Phase phase, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states)
        {
            copies = 0;
            Phase = phase;
        }
        public void AddCopy()
        {
            copies++;
            if (copies >= (int)Rareness)
            {
                Evolve();
                copies = 0;
            }
        }
        sealed public override void Evolve()
        {
            Phase++;
            States.Evolve(2 + (double)Phase / 10);
            base.Evolve();
        }
        public override string Info()
        {
            string text = $"\nType: {this.GetType().Name,-10}\tName: {Name,-10}\tGUID: {Convert.ToString(GUID, 2)}\n" +
                $"Rareness: {Rareness.ToString(),-10}Phase: {Phase.ToString(),-10}Class: {Role.ToString(),-10}Genre: {Genre.ToString()}\n" +
                $"{States.Info()}";
            return (text);
        }
    }
}

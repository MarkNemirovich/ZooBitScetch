using System;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ZooBitSketch
{
    internal class Character : Active
    {
        public int Copies => _copies;
        private int _copies;
        public Character(string name, Phase phase, Rareness rareness, Role role, Genre genre, States states)
            : base(name, phase, rareness, role, genre, states)
        {
            _copies = 0;
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
    }
}

using System;
using System.Drawing;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ZooBitSketch
{
    internal class Character : Active
    {
        public Character(string name, Phase phase, Rareness rareness, Role @class, Genre genre, States states) 
            : base(name, phase, rareness, @class, genre, states)
        {
        }
    }
}

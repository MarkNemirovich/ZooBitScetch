using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives.Clothes
{
    internal class Coat : Clothes
    {
        public Coat(string name, Rareness rareness, Role role, Genre genre, States states)
            : base(name, rareness, role, genre, states) { }
    }
}

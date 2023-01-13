using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class CharactersDeck
    {
        public string Name;
        public List<Character> _deck { get; private set; }
        public CharactersDeck(int size)
        {
            _deck = new List<Character>(size);
        }
    }
}

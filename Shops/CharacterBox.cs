using System;

namespace ZooBitSketch
{
    internal class CharacterBox : Box
    {
        private Gallery _gallery;
        public CharacterBox(string name, int cost, Currency currency, BoxSize size) : base(name, cost, currency, size)
        {
        }
        public Character GetCharacter(Box box, int playerLvl)
        {
            Rareness rareness = box.GetRareness(playerLvl);
            _gallery = new Gallery(rareness);
            Character character = _gallery.GetCharacter();
            return character;
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class CharacterBox : Box
    {
        private CharactersGallery _gallery;
        public CharacterBox(Box baseBox) : base(baseBox.Cost().Item1, baseBox.Cost().Item2, baseBox.Size)
        {

        }
        public CharacterBox(int cost, Currency currency, BoxSize size) : base(cost, currency, size)
        {
        }
        public Character GetCharacter(Box box, int playerLvl)
        {
            Rareness rareness = box.GetRareness(playerLvl);
            _gallery = new CharactersGallery(rareness);
            Character character = _gallery.GetCharacter();
            return character;
        }
    }
}

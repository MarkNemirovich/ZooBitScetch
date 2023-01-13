using System;

namespace ZooBitScetch
{
    internal class Player
    {
        public readonly string Name;
        public int Lvl { get; private set; }
        private int _maxCharactersDeckSize;
        private Purse _purse;
        private CharactersDeck _charactersDeck;
        public Player(string name)
        {
            Name = name;
            Lvl = 1;
            _maxCharactersDeckSize = 50;
            _purse = new Purse();
            _charactersDeck = new CharactersDeck(_maxCharactersDeckSize);
        }
        public override string ToString()
        {
            return $"\nName = {Name}\nLvl = {Lvl}\nMoney = {_purse.Money}\nDiamonds = {_purse.Diamonds}\nCards amount = {_charactersDeck._deck.Count}";
        }
    }
}

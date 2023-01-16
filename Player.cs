using System;

namespace ZooBitSketch
{
    internal class Player
    {
        public readonly string Name;
        public int Lvl { get; private set; }
        public int Exp { get; private set; }
        private int _maxCharactersDeckSize;
        public Purse Purse { get; private set; }
        public Bag Bag { get; private set; }
        public CharactersDeck CharactersDeck { get; private set; }
        public Player(string name)
        {
            Name = name;
            Lvl = 1;
            Exp = 0;
            _maxCharactersDeckSize = 20;
            Purse = new Purse();
            Bag= new Bag();
            CharactersDeck = new CharactersDeck(_maxCharactersDeckSize);
        }
        public void AddExp(int exp)
        {
            Exp+=exp;
            if (Exp > Lvl * 100)
                LvlUP();
        }
        private void LvlUP()
        {
            Exp-= Lvl*100;
            Lvl++;
            if(Lvl%5 == 0)
                _maxCharactersDeckSize++;
        }
        public void Info()
        {
            Console.WriteLine($"\nName = {Name}\nLvl = {Lvl}\n\nPress any key for continue...");
            Console.ReadKey();
        }
    }
}

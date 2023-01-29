using System;

namespace ZooBitSketch.Player
{
    internal class PlayerEntity
    {
        public readonly string Name;
        public int Lvl { get; private set; }
        public int Exp { get; private set; }
        public Wallet Wallet { get; private set; }
        public Bag Bag { get; private set; }
        public Deck Deck { get; private set; }
        public Team Team { get; private set; }
        public Wardrobe Wardrobe { get; private set; }
        private int _maxSize;
        public PlayerEntity(string name)
        {
            Name = name;
            Lvl = 1;
            Exp = 0;
            _maxSize = 1000;
            Wallet = Wallet.GetInstance();
            Bag = new Bag();
            Deck = new Deck(_maxSize);
            Team = new Team(_maxSize);
            Wardrobe = new Wardrobe(_maxSize);

            Team.Decay += Wallet.DecayCharacter;
        }
        public void AddExp(int exp)
        {
            Exp += exp;
            if (Exp > Lvl * 100)
                LvlUP();
        }
        private void LvlUP()
        {
            Exp -= Lvl * 100;
            Lvl++;
            if (Lvl % 5 == 0)
                _maxSize++;
        }
        public void Info()
        {
            Console.WriteLine($"\nName = {Name}\nLvl = {Lvl}\n\nPress any key for continue...");
            Console.ReadKey();
        }
    }
}
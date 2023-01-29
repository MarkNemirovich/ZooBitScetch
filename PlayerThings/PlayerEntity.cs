using System;
using ZooBitSketch.PlayerThings;

namespace ZooBitSketch.Player
{
    internal class PlayerEntity : ICustomer
    {
        public readonly string Name;
        private int _lvl;
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
            _lvl = 1;
            Exp = 0;
            _maxSize = 1000;
            Wallet = Wallet.GetInstance();
            Bag = Bag.GetInstance();
            Deck = new Deck(_maxSize);
            Team = new Team(_maxSize);
            Wardrobe = new Wardrobe(_maxSize);

            Team.Decay += Wallet.DecayCharacter;
        }
        public void AddExp(int exp)
        {
            Exp += exp;
            if (Exp > _lvl * 100)
                LvlUP();
        }
        private void LvlUP()
        {
            Exp -= _lvl * 100;
            _lvl++;
            if (_lvl % 5 == 0)
                _maxSize++;
        }
        public void Info()
        {
            Console.WriteLine($"\nName = {Name}\nLvl = {_lvl}\n\nPress any key for continue...");
            Console.ReadKey();
        }
        public int GetLvl => _lvl;
        public bool Purchase(Currency currency, int cost) => Wallet.GetInstance().Pay(currency, cost);
        public void AddActive(Active active)
        {
            var a = active;
            switch (a)
            {
                case Character:
                    Team.Add(a as Character);
                    break;
                case Clothes:
                    Wardrobe.Add(a as Clothes);
                    break;
                case Card:
                    Deck.Add(a as Card);
                    break;
            }
        }
    }
}
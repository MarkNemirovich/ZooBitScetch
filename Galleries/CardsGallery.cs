using System;

namespace ZooBitSketch
{
    internal class CardsGallery
    {
        private static Random rand = new Random();
        private static States RandomStates(Rareness rareness)
        {
            return new States(rareness);
        }
        private readonly Card[] _ordinary = new Card[]
        {
            new Card("Atack1", CardType.Atack, Phase.Child, Rareness.Ordinary, Role.Singler,Genre.Rap, RandomStates(Rareness.Ordinary)),
            new Card("Buff1", CardType.Buff,Phase.Child, Rareness.Ordinary, Role.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new Card("Bonus1", CardType.Bonus,Phase.Child, Rareness.Ordinary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Ordinary)),
            new Card("Defence1", CardType.Defence, Phase.Child, Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary)),
            new Card("Growth1", CardType.Growth, Phase.Child, Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
        };
        private readonly Card[] _rare = new Card[]
        {
            new Card("Atack2", CardType.Atack,Phase.Child, Rareness.Rare, Role.Singler,Genre.Rap, RandomStates(Rareness.Rare)),
            new Card("Instrument2", CardType.Buff,Phase.Child, Rareness.Rare, Role.Drums,Genre.Rock, RandomStates(Rareness.Rare)),
            new Card("Bonus2", CardType.Bonus,Phase.Child, Rareness.Rare, Role.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new Card("Defence2", CardType.Defence,Phase.Child, Rareness.Rare, Role.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new Card("Growth2", CardType.Growth, Phase.Child, Rareness.Rare, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Rare))
        };
        private readonly Card[] _elite = new Card[]
        {
            new Card("Atack3", CardType.Atack,Phase.Child, Rareness.Elite, Role.Singler,Genre.Rap, RandomStates(Rareness.Elite)),
            new Card("Buff3", CardType.Buff,Phase.Child, Rareness.Elite, Role.Drums,Genre.Rock, RandomStates(Rareness.Elite)),
            new Card("Bonus3", CardType.Bonus,Phase.Child, Rareness.Elite, Role.Guitar,Genre.Pop, RandomStates(Rareness.Elite)),
            new Card("Defence3", CardType.Defence, Phase.Child, Rareness.Elite, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Elite)),
            new Card("Growth3", CardType.Growth, Phase.Child, Rareness.Elite, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Elite))
        };
        private readonly Card[] _epic = new Card[]
        {
            new Card("Atack4", CardType.Atack, Phase.Child, Rareness.Epic, Role.Singler,Genre.Rap, RandomStates(Rareness.Epic)),
            new Card("Buff4", CardType.Buff,Phase.Child, Rareness.Epic, Role.Drums,Genre.Rock, RandomStates(Rareness.Epic)),
            new Card("Bonus4",CardType.Bonus,Phase.Child, Rareness.Epic, Role.Guitar,Genre.Pop, RandomStates(Rareness.Epic)),
            new Card("Defence4", CardType.Defence, Phase.Child, Rareness.Epic, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Epic)),
            new Card("Growth4", CardType.Growth, Phase.Child, Rareness.Epic, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Epic))
        };
        private readonly Card[] _legendary = new Card[]
        {
            new Card("Atack5", CardType.Atack, Phase.Child, Rareness.Legendary, Role.Singler,Genre.Rap, RandomStates(Rareness.Legendary)),
            new Card("Buff5", CardType.Buff, Phase.Child, Rareness.Legendary, Role.Drums,Genre.Rock, RandomStates(Rareness.Legendary)),
            new Card("Bonus5", CardType.Bonus,Phase.Child, Rareness.Legendary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new Card("Defence5", CardType.Defence, Phase.Child, Rareness.Legendary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary)),
            new Card("Growth5", CardType.Growth, Phase.Child, Rareness.Legendary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary))
        };

        public readonly Card[] CardList;
        public CardsGallery(Rareness rareness)
        {
            switch (rareness)
            {
                case Rareness.Ordinary: CardList = _ordinary; break;
                case Rareness.Rare: CardList = _rare; break;
                case Rareness.Elite: CardList = _elite; break;
                case Rareness.Epic: CardList = _epic; break;
                case Rareness.Legendary: CardList = _legendary; break;
            }
        }
        public Card GetCharacter()
        {
            int number = rand.Next(0, CardList.Length);
            return CardList[number];
        }
        public Card[] InitialCard(int size)
        {
            if (size == 0)
                return _ordinary;
            return null;
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class ClothesGallery
    {
        private static Random rand = new Random();
        private static States RandomStates(Rareness rareness)
        {
            return new States(rareness);
        }
        private readonly Clothes[] _ordinary = new Clothes[]
        {
            new Clothes("Boot1", ClothesType.Boots, Phase.Child, Rareness.Ordinary, Role.Singler,Genre.Rap, RandomStates(Rareness.Ordinary)),
            new Clothes("Instrument1", ClothesType.Instrument,Phase.Child, Rareness.Ordinary, Role.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new Clothes("Hat1", ClothesType.Hat,Phase.Child, Rareness.Ordinary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Ordinary)),
            new Clothes("Coat1", ClothesType.Coat, Phase.Child, Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
        };
        private readonly Clothes[] _rare = new Clothes[]
        {
            new Clothes("Boot2", ClothesType.Boots,Phase.Child, Rareness.Rare, Role.Singler,Genre.Rap, RandomStates(Rareness.Rare)),
            new Clothes("Instrument2", ClothesType.Instrument,Phase.Child, Rareness.Rare, Role.Drums,Genre.Rock, RandomStates(Rareness.Rare)),
            new Clothes("Hat2", ClothesType.Hat,Phase.Child, Rareness.Rare, Role.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new Clothes("Coat2", ClothesType.Coat, Phase.Child, Rareness.Rare, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Rare))
        };
        private readonly Clothes[] _elite = new Clothes[]
        {
            new Clothes("Boot3", ClothesType.Boots,Phase.Child, Rareness.Elite, Role.Singler,Genre.Rap, RandomStates(Rareness.Elite)),
            new Clothes("Instrument3", ClothesType.Instrument,Phase.Child, Rareness.Elite, Role.Drums,Genre.Rock, RandomStates(Rareness.Elite)),
            new Clothes("Hat3", ClothesType.Hat,Phase.Child, Rareness.Elite, Role.Guitar,Genre.Pop, RandomStates(Rareness.Elite)),
            new Clothes("Coat3", ClothesType.Coat, Phase.Child, Rareness.Elite, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Elite))
        };
        private readonly Clothes[] _epic = new Clothes[]
        {
            new Clothes("Boot4", ClothesType.Boots, Phase.Child, Rareness.Epic, Role.Singler,Genre.Rap, RandomStates(Rareness.Epic)),
            new Clothes("Instrument4", ClothesType.Instrument,Phase.Child, Rareness.Epic, Role.Drums,Genre.Rock, RandomStates(Rareness.Epic)),
            new Clothes("Hat4",ClothesType.Hat,Phase.Child, Rareness.Epic, Role.Guitar,Genre.Pop, RandomStates(Rareness.Epic)),
            new Clothes("Coat4", ClothesType.Coat, Phase.Child, Rareness.Epic, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Epic))
        };
        private readonly Clothes[] _legendary = new Clothes[]
        {
            new Clothes("Boot5", ClothesType.Boots, Phase.Child, Rareness.Legendary, Role.Singler,Genre.Rap, RandomStates(Rareness.Legendary)),
            new Clothes("Instrument5", ClothesType.Instrument, Phase.Child, Rareness.Legendary, Role.Drums,Genre.Rock, RandomStates(Rareness.Legendary)),
            new Clothes("Hat5", ClothesType.Hat,Phase.Child, Rareness.Legendary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new Clothes("Coat5", ClothesType.Coat, Phase.Child, Rareness.Legendary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary))
        };

        public readonly Clothes[] ClothesList;
        public ClothesGallery(Rareness rareness)
        {
            switch (rareness)
            {
                case Rareness.Ordinary: ClothesList = _ordinary; break;
                case Rareness.Rare: ClothesList = _rare; break;
                case Rareness.Elite: ClothesList = _elite; break;
                case Rareness.Epic: ClothesList = _epic; break;
                case Rareness.Legendary: ClothesList = _legendary; break;
            }
        }
        public Clothes GetCharacter()
        {
            int number = rand.Next(0, ClothesList.Length);
            return ClothesList[number];
        }
        public Clothes[] InitialClothes(int size)
        {
            if (size == 0)
                return _ordinary;
            return null;
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class ClothesGallery : Gallery<Clothes>
    {
        private Clothes[] Ordinary()
        {
            return new Clothes[]
            {
            new Clothes("Stone", ClothesType.Stone, Rareness.Ordinary, Role.Universal, Genre.Universal, new States(Rareness.Ordinary)),
            new Clothes("Boot1", ClothesType.Boots, Rareness.Ordinary, Role.Singler,Genre.Rap, RandomStates(Rareness.Ordinary)),
            new Clothes("Instrument1", ClothesType.Instrument, Rareness.Ordinary, Role.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new Clothes("Hat1", ClothesType.Hat, Rareness.Ordinary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Ordinary)),
            new Clothes("Coat1", ClothesType.Coat, Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
            };
        }
        private Clothes[] Rare()
        {
            return new Clothes[]
            {
            new Clothes("Boot2", ClothesType.Boots, Rareness.Rare, Role.Singler,Genre.Rap, RandomStates(Rareness.Rare)),
            new Clothes("Instrument2", ClothesType.Instrument, Rareness.Rare, Role.Drums,Genre.Rock, RandomStates(Rareness.Rare)),
            new Clothes("Hat2", ClothesType.Hat, Rareness.Rare, Role.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new Clothes("Coat2", ClothesType.Coat, Rareness.Rare, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Rare))
            };
        }
        private Clothes[] Elite()
        {
            return new Clothes[]
            {
            new Clothes("Boot3", ClothesType.Boots, Rareness.Elite, Role.Singler,Genre.Rap, RandomStates(Rareness.Elite)),
            new Clothes("Instrument3", ClothesType.Instrument, Rareness.Elite, Role.Drums,Genre.Rock, RandomStates(Rareness.Elite)),
            new Clothes("Hat3", ClothesType.Hat, Rareness.Elite, Role.Guitar,Genre.Pop, RandomStates(Rareness.Elite)),
            new Clothes("Coat3", ClothesType.Coat, Rareness.Elite, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Elite))
            };
        }
        private Clothes[] Epic()
        {
            return new Clothes[]
            {
            new Clothes("Boot4", ClothesType.Boots, Rareness.Epic, Role.Singler,Genre.Rap, RandomStates(Rareness.Epic)),
            new Clothes("Instrument4", ClothesType.Instrument, Rareness.Epic, Role.Drums,Genre.Rock, RandomStates(Rareness.Epic)),
            new Clothes("Hat4",ClothesType.Hat, Rareness.Epic, Role.Guitar,Genre.Pop, RandomStates(Rareness.Epic)),
            new Clothes("Coat4", ClothesType.Coat, Rareness.Epic, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Epic))
        };
        }
        private Clothes[] Legendary()
        {
            return new Clothes[]
            {
            new Clothes("Boot5", ClothesType.Boots, Rareness.Legendary, Role.Singler,Genre.Rap, RandomStates(Rareness.Legendary)),
            new Clothes("Instrument5", ClothesType.Instrument, Rareness.Legendary, Role.Drums,Genre.Rock, RandomStates(Rareness.Legendary)),
            new Clothes("Hat5", ClothesType.Hat, Rareness.Legendary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new Clothes("Coat5", ClothesType.Coat, Rareness.Legendary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary))
            };
        }
        public ClothesGallery(Rareness rareness)
        {
            _ordinary = Ordinary();
            _rare = Rare();
            _elite = Elite();
            _epic = Epic();
            _legendary = Legendary();
            switch (rareness)
            {
                case Rareness.Ordinary: CurrentList = _ordinary; break;
                case Rareness.Rare: CurrentList = _rare; break;
                case Rareness.Elite: CurrentList = _elite; break;
                case Rareness.Epic: CurrentList = _epic; break;
                case Rareness.Legendary: CurrentList = _legendary; break;
            }
        }
    }
}

using System;
using ZooBitSketch.Enums;
using ZooBitSketch.Property.Actives;
using ZooBitSketch.Property.Actives.Clothes;

namespace ZooBitSketch.Property.Galleries
{
    internal class ClothesGallery : Gallery<Clothes>
    {
        private Clothes[] Ordinary()
        {
            return new Clothes[]
            {
            new Boots("Boot1", Rareness.Ordinary, Role.Singler,Genre.Rap, RandomStates(Rareness.Ordinary)),
            new Instrument("Instrument1", Rareness.Ordinary, Role.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new Hat ("Hat1", Rareness.Ordinary, Role.Guitar, Genre.Pop, RandomStates(Rareness.Ordinary)),
            new Coat("Coat1", Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
            };
        }
        private Clothes[] Rare()
        {
            return new Clothes[]
            {
            new Boots ("Boot2", Rareness.Rare, Role.Singler, Genre.Rap, RandomStates(Rareness.Rare)),
            new Instrument ("Instrument2", Rareness.Rare, Role.Drums, Genre.Rock, RandomStates(Rareness.Rare)),
            new Hat ("Hat2", Rareness.Rare, Role.Guitar, Genre.Pop, RandomStates(Rareness.Rare)),
            new Coat ("Coat2", Rareness.Rare, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Rare))
            };
        }
        private Clothes[] Elite()
        {
            return new Clothes[]
            {
            new Boots ("Boot3", Rareness.Elite, Role.Singler, Genre.Rap, RandomStates(Rareness.Elite)),
            new Instrument ("Instrument3", Rareness.Elite, Role.Drums, Genre.Rock, RandomStates(Rareness.Elite)),
            new Hat ("Hat3", Rareness.Elite, Role.Guitar, Genre.Pop, RandomStates(Rareness.Elite)),
            new Coat ("Coat3", Rareness.Elite, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Elite))
            };
        }
        private Clothes[] Epic()
        {
            return new Clothes[]
            {
            new Boots ("Boot4", Rareness.Epic, Role.Singler, Genre.Rap, RandomStates(Rareness.Epic)),
            new Instrument ("Instrument4", Rareness.Epic, Role.Drums, Genre.Rock, RandomStates(Rareness.Epic)),
            new Hat ("Hat4", Rareness.Epic, Role.Guitar, Genre.Pop, RandomStates(Rareness.Epic)),
            new Coat ("Coat4", Rareness.Epic, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Epic))
        };
        }
        private Clothes[] Legendary()
        {
            return new Clothes[]
            {
            new Boots ("Boot5", Rareness.Legendary, Role.Singler, Genre.Rap, RandomStates(Rareness.Legendary)),
            new Instrument ("Instrument5", Rareness.Legendary, Role.Drums, Genre.Rock, RandomStates(Rareness.Legendary)),
            new Hat("Hat5", Rareness.Legendary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new Coat ("Coat5", Rareness.Legendary, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Legendary))
            };
        }
        public ClothesGallery(Rareness rareness) : base()
        {
            allActives.TryAdd(Rareness.Ordinary, Ordinary());
            allActives.TryAdd(Rareness.Rare, Rare());
            allActives.TryAdd(Rareness.Elite, Elite());
            allActives.TryAdd(Rareness.Epic, Epic());
            allActives.TryAdd(Rareness.Legendary, Legendary());
            allActives.TryGetValue(rareness, out Clothes[] currentPack);
            CurrentPack = currentPack;
        }
    }
}

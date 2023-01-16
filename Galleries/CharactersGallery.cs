using System;

namespace ZooBitSketch
{ 
    internal class CharactersGallery : Gallery<Character>
    {
        private Character[] Ordinary()
        {
            return new Character[]
            {
            new Character("Dog", Phase.Child, Rareness.Ordinary, Role.Singler,Genre.Rap, RandomStates(Rareness.Ordinary)),
            new Character("Cat", Phase.Child, Rareness.Ordinary, Role.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new Character("Rabbit", Phase.Child, Rareness.Ordinary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Ordinary)),
            new Character("Sheep", Phase.Child, Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
            };
        }
        private Character[] Rare()
        {
            return new Character[]
            {
            new Character("Fox", Phase.Child, Rareness.Rare, Role.Singler,Genre.Rap, RandomStates(Rareness.Rare)),
            new Character("Leopard", Phase.Child, Rareness.Rare, Role.Drums,Genre.Rock, RandomStates(Rareness.Rare)),
            new Character("Scwirrel", Phase.Child, Rareness.Rare, Role.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new Character("Horse", Phase.Child, Rareness.Rare, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Rare))
            };
        }
        private Character[] Elite()
        {
            return new Character[]
            {
            new Character("Wolf", Phase.Child, Rareness.Elite, Role.Singler,Genre.Rap, RandomStates(Rareness.Elite)),
            new Character("Puma", Phase.Child, Rareness.Elite, Role.Drums,Genre.Rock, RandomStates(Rareness.Elite)),
            new Character("Humster", Phase.Child, Rareness.Elite, Role.Guitar,Genre.Pop, RandomStates(Rareness.Elite)),
            new Character("Zebra", Phase.Child, Rareness.Elite, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Elite))
        };
        }
        private Character[] Epic()
        {
            return new Character[]
            {
            new Character("Bear", Phase.Child, Rareness.Epic, Role.Singler,Genre.Rap, RandomStates(Rareness.Epic)),
            new Character("Tiger", Phase.Child, Rareness.Epic, Role.Drums,Genre.Rock, RandomStates(Rareness.Epic)),
            new Character("Marmot",Phase.Child, Rareness.Epic, Role.Guitar,Genre.Pop, RandomStates(Rareness.Epic)),
            new Character("Deer", Phase.Child, Rareness.Epic, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Epic))
        };
        }
        private Character[] Legendary()
        {
            return new Character[]
            {
            new Character("Monkey", Phase.Child, Rareness.Legendary, Role.Singler,Genre.Rap, RandomStates(Rareness.Legendary)),
            new Character("Lion", Phase.Child, Rareness.Legendary, Role.Drums,Genre.Rock, RandomStates(Rareness.Legendary)),
            new Character("Hedgehog", Phase.Child, Rareness.Legendary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new Character("Elephant", Phase.Child, Rareness.Legendary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary))
            };
        }
        public CharactersGallery(Rareness rareness)
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

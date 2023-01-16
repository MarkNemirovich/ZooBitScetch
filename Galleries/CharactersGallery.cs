using System;

namespace ZooBitSketch
{ 
    internal class CharactersGallery
    {
        private static Random rand = new Random();
        private static States RandomStates(Rareness rareness)
        {
            return new States(rareness);
        }
        private readonly Character[] _ordinary = new Character[]
        {
            new Character("Dog", Phase.Child, Rareness.Ordinary, Class.Singler,Genre.Rep, RandomStates(Rareness.Ordinary)),
            new Character("Cat", Phase.Child, Rareness.Ordinary, Class.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new Character("Rabbit", Phase.Child, Rareness.Ordinary, Class.Guitar,Genre.Pop, RandomStates(Rareness.Ordinary)),
            new Character("Sheep", Phase.Child, Rareness.Ordinary, Class.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
        };
        private readonly Character[] _rare = new Character[]
        {
            new Character("Fox", Phase.Child, Rareness.Rare, Class.Singler,Genre.Rep, RandomStates(Rareness.Rare)),
            new Character("Leopard", Phase.Child, Rareness.Rare, Class.Drums,Genre.Rock, RandomStates(Rareness.Rare)),
            new Character("Scwirrel", Phase.Child, Rareness.Rare, Class.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new Character("Horse", Phase.Child, Rareness.Rare, Class.Pianist,Genre.Reggae, RandomStates(Rareness.Rare))
        };
        private readonly Character[] _elite = new Character[]
        {
            new Character("Wolf", Phase.Child, Rareness.Elite, Class.Singler,Genre.Rep, RandomStates(Rareness.Elite)),
            new Character("Puma", Phase.Child, Rareness.Elite, Class.Drums,Genre.Rock, RandomStates(Rareness.Elite)),
            new Character("Humster", Phase.Child, Rareness.Elite, Class.Guitar,Genre.Pop, RandomStates(Rareness.Elite)),
            new Character("Zebra", Phase.Child, Rareness.Elite, Class.Pianist,Genre.Reggae, RandomStates(Rareness.Elite))
        };
        private readonly Character[] _epic = new Character[]
        {
            new Character("Bear", Phase.Child, Rareness.Epic, Class.Singler,Genre.Rep, RandomStates(Rareness.Epic)),
            new Character("Tiger", Phase.Child, Rareness.Epic, Class.Drums,Genre.Rock, RandomStates(Rareness.Epic)),
            new Character("Marmot",Phase.Child, Rareness.Epic, Class.Guitar,Genre.Pop, RandomStates(Rareness.Epic)),
            new Character("Deer", Phase.Child, Rareness.Epic, Class.Pianist,Genre.Reggae, RandomStates(Rareness.Epic))
        };
        private readonly Character[] _legendary = new Character[]
        {
            new Character("Monkey", Phase.Child, Rareness.Legendary, Class.Singler,Genre.Rep, RandomStates(Rareness.Legendary)),
            new Character("Lion", Phase.Child, Rareness.Legendary, Class.Drums,Genre.Rock, RandomStates(Rareness.Legendary)),
            new Character("Hedgehog", Phase.Child, Rareness.Legendary, Class.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new Character("Elephant", Phase.Child, Rareness.Legendary, Class.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary))
        };

        public readonly Character[] CharactersList;
        public CharactersGallery(Rareness rareness)
        {
            switch (rareness)
            {
                case Rareness.Ordinary: CharactersList = _ordinary; break;
                case Rareness.Rare: CharactersList = _rare; break;
                case Rareness.Elite: CharactersList = _elite; break;
                case Rareness.Epic: CharactersList = _epic; break;
                case Rareness.Legendary: CharactersList = _legendary; break;
            }
        }
        public Character GetCharacter()
        {
            int number = rand.Next(0, CharactersList.Length);
            return CharactersList[number];
        }
        public Character[] InitialCharacters(int size)
        {
            if (size == 0)
                return _ordinary;
            return null;
        }
    }
}

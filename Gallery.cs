using System;

namespace ZooBitSketch
{ 
    internal class Gallery
    {
        private static Random rand = new Random();
        private readonly Character[] _ordinary = new Character[]
        {
            new Character("Dog", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100), 
                Phase.Child, Rareness.Ordinary, Class.Singler,Genre.Rep),

            new Character("Cat", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Drums,Genre.Rock),

            new Character("Rabbit", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Guitar,Genre.Pop),

            new Character("Sheep", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _rare = new Character[]
        {
            new Character("Fox",2* rand.Next(0,100), 2*rand.Next(0,100),2*rand.Next(0,100), 2*rand.Next(0,100), 2*rand.Next(0,100),
                Phase.Child, Rareness.Rare, Class.Singler,Genre.Rep),
            new Character("Leopard", 2*rand.Next(0,100), 2*rand.Next(0,100),2*rand.Next(0,100), 2*rand.Next(0,100), 2*rand.Next(0,100),
                Phase.Child, Rareness.Rare, Class.Drums,Genre.Rock),

            new Character("Scwirrel", 2*rand.Next(0,100), 2*rand.Next(0,100),2*rand.Next(0,100), 2*rand.Next(0,100), 2*rand.Next(0,100),
                Phase.Child, Rareness.Rare, Class.Guitar,Genre.Pop),

            new Character("Horse", 2*rand.Next(0,100), 2*rand.Next(0,100),2*rand.Next(0,100), 2*rand.Next(0,100), 2*rand.Next(0,100),
                Phase.Child, Rareness.Rare, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _elite = new Character[]
        {
            new Character("Wolf", 3*rand.Next(0,100), 3*rand.Next(0,100),3*rand.Next(0,100), 3*rand.Next(0,100), 3*rand.Next(0,100),
                Phase.Child, Rareness.Elite, Class.Singler,Genre.Rep),
            new Character("Puma", 3*rand.Next(0,100), 3*rand.Next(0,100),3*rand.Next(0,100), 3*rand.Next(0,100), 3*rand.Next(0,100),
                Phase.Child, Rareness.Elite, Class.Drums,Genre.Rock),

            new Character("Humster", 3*rand.Next(0,100), 3*rand.Next(0,100),3*rand.Next(0,100), 3*rand.Next(0,100), 3*rand.Next(0,100),
                Phase.Child, Rareness.Elite, Class.Guitar,Genre.Pop),

            new Character("Zebra", 3*rand.Next(0,100), 3*rand.Next(0,100),3*rand.Next(0,100), 3*rand.Next(0,100), 3*rand.Next(0,100),
               Phase.Child, Rareness.Elite, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _epic = new Character[]
        {
            new Character("Bear", 4*rand.Next(0,100), 4*rand.Next(0,100),4*rand.Next(0,100),4*rand.Next(0,100), 4*rand.Next(0,100),
                Phase.Child, Rareness.Epic, Class.Singler,Genre.Rep),
            new Character("Tiger", 4*rand.Next(0,100), 4*rand.Next(0,100),4*rand.Next(0,100),4*rand.Next(0,100), 4*rand.Next(0,100),
                Phase.Child, Rareness.Epic, Class.Drums,Genre.Rock),

            new Character("Marmot", 4*rand.Next(0,100), 4*rand.Next(0,100),4*rand.Next(0,100),4*rand.Next(0,100), 4*rand.Next(0,100),
                Phase.Child, Rareness.Epic, Class.Guitar,Genre.Pop),

            new Character("Deer", 4*rand.Next(0,100), 4*rand.Next(0,100),4*rand.Next(0,100),4*rand.Next(0,100), 4*rand.Next(0,100),
                Phase.Child, Rareness.Epic, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _legendary = new Character[]
        {
            new Character("Monkey", 5*rand.Next(0,100), 5*rand.Next(0,100),5*rand.Next(0,100),5*rand.Next(0,100), 5*rand.Next(0,100),
                Phase.Child, Rareness.Legendary, Class.Singler,Genre.Rep),

            new Character("Lion", 5*rand.Next(0,100), 5*rand.Next(0,100),5*rand.Next(0,100),5*rand.Next(0,100), 5*rand.Next(0,100),
                Phase.Child, Rareness.Legendary, Class.Drums,Genre.Rock),

            new Character("Hedgehog", 5*rand.Next(0,100), 5*rand.Next(0,100),5*rand.Next(0,100),5*rand.Next(0,100), 5*rand.Next(0,100),
                Phase.Child, Rareness.Legendary, Class.Guitar,Genre.Pop),

            new Character("Elephant", 5*rand.Next(0,100), 5*rand.Next(0,100),5*rand.Next(0,100),5*rand.Next(0,100), 5*rand.Next(0,100),
                Phase.Child, Rareness.Legendary, Class.Pianist,Genre.Reggae),
        };

        public readonly Character[] CharactersList;
        public Gallery(Rareness rareness)
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

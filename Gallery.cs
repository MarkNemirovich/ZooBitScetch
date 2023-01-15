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
            new Character("Fox", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Singler,Genre.Rep),
            new Character("Leopard", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Drums,Genre.Rock),

            new Character("Scwirrel", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Guitar,Genre.Pop),

            new Character("Horse", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _elite = new Character[]
        {
            new Character("Wolf", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Singler,Genre.Rep),
            new Character("Puma", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Drums,Genre.Rock),

            new Character("Humster", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Guitar,Genre.Pop),

            new Character("Zebra", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
               Phase.Child, Rareness.Ordinary, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _epic = new Character[]
        {
            new Character("Bear", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Singler,Genre.Rep),
            new Character("Tiger", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Drums,Genre.Rock),

            new Character("Marmot", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Guitar,Genre.Pop),

            new Character("Deer", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Pianist,Genre.Reggae),
        };
        private readonly Character[] _legendary = new Character[]
        {
            new Character("Monkey", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Singler,Genre.Rep),

            new Character("Lion", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Drums,Genre.Rock),

            new Character("Hedgehog", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Guitar,Genre.Pop),

            new Character("Elephant", rand.Next(0,100), rand.Next(0,100),rand.Next(0,100), rand.Next(0,100), rand.Next(0,100),
                Phase.Child, Rareness.Ordinary, Class.Pianist,Genre.Reggae),
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

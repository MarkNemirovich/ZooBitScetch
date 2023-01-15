using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class CharactersDeck
    {
        public string Name;
        public List<Character> _deck { get; private set; }
        public CharactersDeck(int size)
        {
            _deck = new List<Character>(size);
            Gallery gallery = new Gallery(Rareness.Ordinary);
            TryAddCards(gallery.InitialCharacters(_deck.Count));
        }
        public bool TryAddCards(Character[] newCharacters)
        {
            if (_deck.Count + newCharacters.Length < _deck.Capacity)
            {
                Console.Clear();
                _deck.AddRange(newCharacters);
                foreach (Character character in newCharacters)
                    Console.WriteLine(character.Info());
                Console.WriteLine("You have got these characters. Congradulations!\nPress any key for continue...");
                Console.ReadKey();
                return true;
            }
            Console.WriteLine("No character with such number. Check your input\nPress any key for continue...");
            Console.ReadKey();
            return false;
        }
        public void Info()
        {
            string request;
            do
            {
                WriteList();
                request = Console.ReadLine();
                if (Int32.TryParse(request, out int result) && result > 0 && result <= _deck.Count)
                {
                    Console.WriteLine(_deck[result-1].Info() + "\nPress any key for continue...");
                    Console.ReadKey();
                }
                else if (request != "exit")
                {
                    Console.WriteLine("No character with such number. Check your input\nPress any key for continue...");
                    Console.ReadKey();
                }
            } while (request != "exit");
        }
        private void WriteList()
        {
            Console.Clear();
            Console.WriteLine($"Amount of characters you have is {_deck.Count}\nMaximum amoun is {_deck.Capacity}.\n" +
                $"If you want to know anything about character, white ID. For exit write \"exit.\"\n");
            for (int i = 0; i < _deck.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_deck[i].Name}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;

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
            TryAddCards(gallery.InitialCharacters(_deck.Count), out int DNA);
        }
        public bool TryAddCards(Character[] newCharacters, out int DNA)
        {
            DNA = 0;
            if (_deck.Count + newCharacters.Length < _deck.Capacity)
            {
                Console.Clear();
                foreach (Character character in newCharacters)
                {
                    if (_deck.Any(deck=>deck.Name == character.Name))
                    {
                        Character copy = _deck.First(deck => deck.Name == character.Name);
                        if (copy.Phase < Phase.Adult)
                            copy.Evolve();
                        else
                            DNA += (int)character.Rareness;
                    }
                    else
                        _deck.Add(character);
                    (string text, ConsoleColor color) = character.Info();
                    Console.ForegroundColor = color;
                    Console.WriteLine(text);
                    Console.ForegroundColor = ConsoleColor.White;
                }
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
                    (string text, ConsoleColor color) = _deck[result - 1].Info();
                    Console.ForegroundColor = color;
                    Console.WriteLine(text);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key for continue...");
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

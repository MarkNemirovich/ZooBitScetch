using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ZooBitSketch
{
    internal class CharactersDeck
    {
        public string Name;
        public List<(Character card, int copies)> _deck { get; private set; }
        public CharactersDeck(int size)
        {
            _deck = new List<(Character, int)>(size);
            CharactersGallery gallery = new CharactersGallery(Rareness.Ordinary);
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
                    if (_deck.Any(deck=>deck.card.Name == character.Name))
                    {
                        var copy = _deck.First(deck => deck.card.Name == character.Name);
                        int index = _deck.IndexOf(copy);
                        if (copy.card.Phase < Phase.Adult)
                        {
                            copy.copies++;
                            if (copy.copies >= (int)copy.card.Rareness)
                            {
                                copy.card.Evolve();
                                copy.copies = 0;
                            }
                            _deck[index] = copy;
                        }
                        else
                            DNA += (int)character.Rareness;
                    }
                    else
                        _deck.Add((character, 0));
                    Console.WriteLine(character.Info(), Console.ForegroundColor = character.ChooseColor());
                    Console.ForegroundColor = ConsoleColor.White;
                }
                Console.WriteLine("You have got these characters. Congradulations!\nPress any key for continue...");
                Console.ReadKey();
                return true;
            }
            Console.WriteLine("You have no enough place in the team. Buy more.\nPress any key for continue...");
            Console.ReadKey();
            return false;
        }
        public void Info()
        {
            _deck.Sort(delegate ((Character card, int copies) x, (Character card, int copies) y)
            {
                return x.card.CompareTo(y.card);
            });
            string request;
            do
            {
                WriteList();
                request = Console.ReadLine();
                if (Int32.TryParse(request, out int result) && result > 0 && result <= _deck.Count)
                {
                    string text = _deck[result - 1].card.Info();
                    text += $"\nCopies for evolution: {_deck[result - 1].copies}/{(int)_deck[result - 1].card.Rareness}";
                    Console.WriteLine(text, Console.ForegroundColor = _deck[result - 1].card.ChooseColor());
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
                Console.WriteLine($"{i + 1} - {_deck[i].card.Name} {_deck[i].card.Rareness} {_deck[i].card.Phase}", Console.ForegroundColor = _deck[i].card.ChooseColor());
            }
        }
    }
}

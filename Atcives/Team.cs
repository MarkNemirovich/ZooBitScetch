using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ZooBitSketch
{
    internal class Team
    {
        public string Name;
        public List<(Character card, int copies)> _team { get; private set; }
        public Team(int size)
        {
            _team = new List<(Character, int)>(size);
            CharactersGallery gallery = new CharactersGallery(Rareness.Ordinary);
            TryAddCards(gallery.InitialCharacters(_team.Count), out int DNA);
        }
        public bool TryAddCards(Character[] newCharacters, out int DNA)
        {
            DNA = 0;
            if (_team.Count + newCharacters.Length < _team.Capacity)
            {
                Console.Clear();
                foreach (Character character in newCharacters)
                {
                    if (_team.Any(deck=>deck.card.Name == character.Name))
                    {
                        var copy = _team.First(deck => deck.card.Name == character.Name);
                        int index = _team.IndexOf(copy);
                        if (copy.card.Phase < Phase.Adult)
                        {
                            copy.copies++;
                            if (copy.copies >= (int)copy.card.Rareness)
                            {
                                copy.card.Evolve();
                                copy.copies = 0;
                            }
                            _team[index] = copy;
                        }
                        else
                            DNA += (int)character.Rareness;
                    }
                    else
                        _team.Add((character, 0));
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
            _team.Sort(delegate ((Character card, int copies) x, (Character card, int copies) y)
            {
                return x.card.CompareTo(y.card);
            });
            string request;
            do
            {
                WriteList();
                request = Console.ReadLine();
                if (Int32.TryParse(request, out int result) && result > 0 && result <= _team.Count)
                {
                    string text = _team[result - 1].card.Info();
                    text += $"\nCopies for evolution: {_team[result - 1].copies}/{(int)_team[result - 1].card.Rareness}";
                    Console.WriteLine(text, Console.ForegroundColor = _team[result - 1].card.ChooseColor());
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
            Console.WriteLine($"Amount of characters you have is {_team.Count}\nMaximum amoun is {_team.Capacity}.\n" +
                $"If you want to know anything about character, white ID. For exit write \"exit.\"\n");
            for (int i = 0; i < _team.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {_team[i].card.Name} {_team[i].card.Rareness} {_team[i].card.Phase}", Console.ForegroundColor = _team[i].card.ChooseColor());
            }
        }
    }
}

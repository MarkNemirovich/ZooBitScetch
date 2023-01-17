using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ZooBitSketch
{
    internal class Team<T> : AbstractPack<Character>
    {
        public Team(int size) : base(size)
        {
            CharactersGallery gallery = new CharactersGallery(Rareness.Ordinary);
            TryAddCards(gallery.StartedPack(Team.Count), out int DNA);
        }
        public bool TryAddCards(Character[] newCharacters, out int DNA)
        {
            DNA = 0;
            if (Team.Count + newCharacters.Length < Team.Capacity)
            {
                Console.Clear();
                foreach (Character character in newCharacters)
                {
                    if (Team.Any(deck=>deck.Name == character.Name))
                    {
                        var copy = Team.First(deck => deck.Name == character.Name);
                        int index = Team.IndexOf(copy);
                        if (copy.Phase < Phase.Adult)
                            Team[index].AddCopy();
                        else
                            DNA += (int)character.Rareness;
                    }
                    else
                        Team.Add(character);
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
        sealed public override void Info()
        {
            Team.Sort(delegate (Character x, Character y)
            {
                return x.CompareTo(y);
            });
            string request;
            do
            {
                WriteList();
                request = Console.ReadLine();
                if (Int32.TryParse(request, out int result) && result > 0 && result <= Team.Count)
                {
                    string text = Team[result - 1].Info();
                    text += $"\nCopies for evolution: {Team[result - 1].Copies}/{(int)Team[result - 1].Rareness}";
                    Console.WriteLine(text, Console.ForegroundColor = Team[result - 1].ChooseColor());
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
        sealed protected override void WriteList()
        {
            base.WriteList();
            Console.WriteLine($"Amount of characters you have is {Team.Count}\nMaximum amoun is {Team.Capacity}.\n" +
                $"If you want to know anything about character, white ID. For exit write \"exit.\"\n");
            for (int i = 0; i < Team.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Team[i].Name} {Team[i].Rareness} {Team[i].Phase}", Console.ForegroundColor = Team[i].ChooseColor());
            }
        }
    }
}

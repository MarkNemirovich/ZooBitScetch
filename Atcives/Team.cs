using System;
using System.Linq;

namespace ZooBitSketch
{
    internal class Team<T> : AbstractPack<Character>
    {
        public event Action<Rareness> Decay;
        public Team(int size) : base(size)
        {
            CharactersGallery gallery = new CharactersGallery(Rareness.Ordinary);
            var initialParty = gallery.StartedPack(Pack.Count);
            foreach (var part in initialParty)
            {
                Add(part);
            }
            Console.ReadLine();
        }
        sealed public override void Add(Character newItem)
        {
            if (Pack.Any(deck => deck.Name == newItem.Name))
            {
                var copy = Pack.First(deck => deck.Name == newItem.Name);
                int index = Pack.IndexOf(copy);
                if (copy.Phase < Phase.Adult)
                    Pack[index].AddCopy();
                else
                    Decay?.Invoke(newItem.Rareness);
            }
            else
                Pack.Add(newItem);
            Console.WriteLine(newItem.Info());
        }
        sealed public override void Info()
        {
            Pack.Sort(delegate (Character x, Character y)
            {
                return x.CompareTo(y);
            });
            string request;
            do
            {
                WriteList();
                request = Console.ReadLine();
                if (Int32.TryParse(request, out int result) && result > 0 && result <= Pack.Count)
                {
                    string text = Pack[result - 1].Info();
                    text += $"\nCopies for evolution: {Pack[result - 1].Copies}/{(int)Pack[result - 1].Rareness}";
                    Console.WriteLine(text, Console.ForegroundColor = Pack[result - 1].ChooseColor());
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
            Console.WriteLine($"Amount of characters you have is {Pack.Count}\nMaximum amount is {Pack.Capacity}.\n" +
                $"If you want to know anything about character, white ID. For exit write \"exit.\"\n");
            for (int i = 0; i < Pack.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {Pack[i].Name} {Pack[i].Rareness} {Pack[i].Phase}", Console.ForegroundColor = Pack[i].ChooseColor());
            }
        }
    }
}

using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZooBitSketch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name;
            do
            {
                Console.Clear();
                Console.WriteLine("Write the name, using only ENG letters.\nNo more than 15 symbols.\nFirst have to be capital.\n");
                name = Console.ReadLine();
            } while (!name.All(char.IsLetter) || (name[0] < 'A' || name[0] > 'Z') || (name.Substring(1).Any(letter => letter >= 'A' && letter <= 'Z')) || (name.Length == 0 || name.Length > 16));
            
            Player player = new Player(name);
            CharactersShop charactersShop = new CharactersShop();
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("If you want to get info, choose one of them. For exit write \"exit.\"\n" +
                    "player\npurse\nbag\ncharactersShop\ncharactersDeck\n");
                input = Console.ReadLine();
                if (String.Equals(input, "player"))
                    player.Info();
                if (String.Equals(input, "purse"))
                    player.Purse.Info();
                if (String.Equals(input, "bag"))
                    player.Bag.Info();
                if (String.Equals(input, "charactersDeck"))
                    player.CharactersDeck.Info();
                if (String.Equals(input, "charactersShop"))
                    charactersShop.Info();
            } while (input != "exit");
        }
    }
}

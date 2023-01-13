using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace ZooBitScetch
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
            Player _player = new Player(name);
            Console.WriteLine(_player.ToString());

            CharactersShop charactersShop = new CharactersShop();
            charactersShop.Info();
        }
    }
}

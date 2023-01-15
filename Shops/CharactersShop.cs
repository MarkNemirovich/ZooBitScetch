using System;

namespace ZooBitSketch
{
    internal class CharactersShop : Shop
    {
        public CharactersShop(string name, Box[] boxes) : base(name, boxes)
        {
        }
        public void Info(int playerLvl)
        {
            string answer;
            do
            {
                WriteList();
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= Boxes.Length)
                {
                    Console.WriteLine(Boxes[selection - 1].Info(playerLvl) +"\nPress any key for continue...");
                }
                else
                    Console.WriteLine("No such item in the shop\nPress any key for continue...");
                Console.ReadKey();
            } while (answer != "exit");
        }
        private void WriteList()
        {
            Console.Clear();
            Console.WriteLine($"We have 6 boxes:\nWhat box do you interested in?\nFor exit write \"exit.\"");
            for (int i = 1; i <= Boxes.Length; i++)
                Console.WriteLine($"{i} - {Boxes[i - 1].Name()}");
        }
    }
}

using System;

namespace ZooBitSketch
{
    internal class CharactersShop : Shop
    {
        public CharactersShop(string name, Box[] boxes) : base(name, boxes)
        {
        }
        public void Info(Player player)
        {
            string answer;
            do
            {
                WriteList();
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= Boxes.Length)
                {
                    Console.WriteLine(Boxes[selection - 1].Info(player.Lvl) +"\nPress any key for continue...");
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
        public bool Purchase(Player player, CharactersDeck deck, CharacterBox box)
        {
            try
            {
                (int Cost, Currency Currency) = box.Cost();
                switch (Currency)
                {
                    case Currency.Money:
                        if (player.Purse.Money >= Cost)
                        {
                            if (deck.TryAddCards(OpenBox(box, player.Lvl)))
                                return true;
                        }
                        else
                        {
                            Console.WriteLine("You have not enough money");
                            return false;
                        }
                        break;
                    case Currency.Diamonds:
                        break;
                }
                return true;
            }
            catch { return false; }
        }
        private Character[] OpenBox(CharacterBox box, int playerLvl)
        {
            Character[] characters = new Character[(int)box.Size()];
            for (int i = 0; i < characters.Length; i++)
                characters[i] = box.GetCharacter(box, playerLvl);
            return characters;
        }
    }
}

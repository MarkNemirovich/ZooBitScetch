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
        public CharacterBox ChooseBox(Player player)
        {
            string answer;
            int selection;
            while (true)
            {
                WriteList();
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out selection) && selection > 0 && selection <= Boxes.Length)
                {
                    Console.WriteLine(Boxes[selection - 1].Info(player.Lvl) + "\nPress any key for continue...");
                    break;
                }
                else
                    Console.WriteLine("No such item in the shop\nPress any key for continue...");
                Console.ReadKey();
            }
            return new CharacterBox(Boxes[selection - 1]);
        }
        private void WriteList()
        {
            Console.Clear();
            Console.WriteLine($"We have 6 boxes:\nWhat box do you interested in?\nFor exit write \"exit.\"");
            for (int i = 1; i <= Boxes.Length; i++)
                Console.WriteLine($"{i} - {Boxes[i - 1].Name()}");
        }
        public bool Purchase(Player player, out int pay)
        {
            CharactersDeck deck = player.CharactersDeck;
            CharacterBox box = ChooseBox(player);
            Console.Clear();
            pay = 0;
            try
            {
                (int Cost, Currency Currency) = box.Cost();
                switch (Currency)
                {
                    case Currency.Money:
                        if (player.Purse.Money >= Cost)
                        {
                            if (deck.TryAddCards(OpenBox(box, player.Lvl)))
                            {
                                pay = Cost;
                                return true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have not enough money\nPress any key for continue...");
                            Console.ReadKey();
                            return false;
                        }
                        break;
                    case Currency.Diamonds:
                        if (player.Purse.Diamonds >= Cost)
                        {
                            if (deck.TryAddCards(OpenBox(box, player.Lvl)))
                            {
                                pay = Cost;
                                return true;
                            }
                        }
                        else
                        {
                            Console.WriteLine("You have not enough diamonds\nPress any key for continue...");
                            Console.ReadKey();
                            return false;
                        }
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

using System;
using System.Runtime.InteropServices.WindowsRuntime;

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
                {
                    if (answer == "exit")
                        return null;
                    Console.WriteLine("No such item in the shop\nPress any key for continue...");
                }
                    Console.ReadKey();
            }
            return new CharacterBox(Boxes[selection - 1]);
        }
        public void Purchase(Player player)
        {
            try
            {
                while (true)
                {
                    CharactersDeck deck = player.CharactersDeck;
                    CharacterBox box = ChooseBox(player);
                    Console.Clear();
                    if (box == null)
                        return;
                    (int Cost, Currency Currency) = box.Cost();
                    switch (Currency)
                    {
                        case Currency.Money:
                            if (player.Purse.Money >= Cost)
                            {
                                if (deck.TryAddCards(OpenBox(box, player.Lvl), out int DNA))
                                {
                                    player.Purse.Spend(box.Cost(), DNA);
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have not enough money\nPress any key for continue...");
                                Console.ReadKey();
                                continue;
                            }
                            break;
                        case Currency.Diamonds:
                            if (player.Purse.Diamonds >= Cost)
                            {
                                if (deck.TryAddCards(OpenBox(box, player.Lvl), out int DNA))
                                {
                                    player.Purse.Spend(box.Cost(), DNA);
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("You have not enough diamonds\nPress any key for continue...");
                                Console.ReadKey();
                                continue;
                            }
                            break;
                    }
                }
            }
            catch { }
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

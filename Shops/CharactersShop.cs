using System;
using System.Runtime.InteropServices.WindowsRuntime;

namespace ZooBitSketch
{
    internal class CharactersShop : Shop
    {
        public CharactersShop() : base("Characters shop", new Box[]
        {   new GeneralBox( 10, Currency.Money, BoxSize.Small ),
            new GeneralBox( 50, Currency.Money, BoxSize.Middle ),
            new GeneralBox( 100, Currency.Money, BoxSize.Large ),
            new GeneralBox( 10, Currency.Diamonds, BoxSize.Small ),
            new GeneralBox( 50, Currency.Diamonds, BoxSize.Middle ),
            new GeneralBox( 100, Currency.Diamonds, BoxSize.Large )
        }) { }
        public void Info(Player player)
        {
            string answer;
            do
            {
                Description();
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
                Description();
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out selection) && selection > 0 && selection <= Boxes.Length)
                {
                    Boxes[selection - 1].Open();
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
                    Team<Character> deck = player.Team;
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
            Character[] characters = new Character[(int)box.Size];
            for (int i = 0; i < characters.Length; i++)
                characters[i] = box.GetCharacter(box, playerLvl);
            return characters;
        }
    }
}

using System;
using System.Linq;
using ZooBitSketch.Player;

namespace ZooBitSketch
{
    internal class Program
    {
        static void Main()
        {
            string name;
            do
            {
                Console.Clear();
                Console.WriteLine("Write the name, using only ENG letters.\nNo more than 15 symbols.\nFirst have to be capital.\n");
                name = Console.ReadLine();
            } while (!name.All(char.IsLetter) || name[0] < 'A' || name[0] > 'Z' || name[1..].Any(letter => letter >= 'A' && letter <= 'Z') || name.Length == 0 || name.Length > 16);

            PlayerEntity player = new PlayerEntity(name);
            CommonBanner Cbanner = new CommonBanner();
            EliteBanner Ebanner = new EliteBanner();
            FriendBanner Fbanner = new FriendBanner();
            GenreBanner Gbanner = new GenreBanner(Genre.Rock);
            CardsWorkshop Workshop = new CardsWorkshop(player.Deck.Pack);
            Smithy Smithy = new Smithy(player.Wardrobe.Pack);
            Smithy.EnhenceSurplus += player.Bag.AddSurplusEnhanceMaterial;
            CharacterShop Cshop = new CharacterShop();

            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("If you want to get info, choose one of them. For exit write \"exit.\"\n" +
                    "Player\nWallet\nBag\nDeck\nTeam\nWardrobe\n" +
                    "Cbanner\nEbanner\nFbanner\nGbanner\nWorkshop\nSmithy\nCshop\n");
                input = Console.ReadLine();
                switch (input)
                {
                    case "Player": player.Info(); break;
                    case "Wallet": player.Wallet.Info(); break;
                    case "Bag": player.Bag.Info(); break;
                    case "Deck": player.Deck.Info(); break;
                    case "Team": player.Team.Info(); break;
                    case "Wardrobe": player.Wardrobe.Info(); break;
                    case "Cbanner": Cbanner.Entry(player); break;
                    case "Ebanner": Ebanner.Entry(player); break;
                    case "Fbanner": Fbanner.Entry(player); break;
                    case "Gbanner": Gbanner.Entry(player); break;
                    case "Workshop": Workshop.Enhance(); break;
                    case "Smithy": Smithy.Enhance(); Smithy.EnhenceSurplus -= player.Bag.AddSurplusEnhanceMaterial; break;
                    case "Cshop": Cshop.Entry(player); break;
                    default: Console.WriteLine("No such command"); break;
                }
            } while (input != "exit");
        }
    }
}
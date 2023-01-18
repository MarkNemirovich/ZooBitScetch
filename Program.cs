﻿using System;
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

            GeneralShop Shop = new GeneralShop();
            string input;
            do
            {
                Console.Clear();
                Console.WriteLine("If you want to get info, choose one of them. For exit write \"exit.\"\n" +
                    "Player\nWallet\nBag\nDeck\nTeam\nWardrobe\nShop\n");
                input = Console.ReadLine();
                switch (input)
                {
                    case "Player": player.Info(); break;
                    case "Wallet": player.Wallet.Info(); break;
                    case "Bag": player.Bag.Info(); break;
                    case "Deck": player.Deck.Info(); break;
                    case "Team": player.Team.Info(); break;
                    case "Wardrobe": player.Wardrobe.Info(); break;
                    case "Shop": Shop.Entry(player); break;
                    default: Console.WriteLine("No such command"); break;
                }
            } while (input != "exit");
        }
    }
}
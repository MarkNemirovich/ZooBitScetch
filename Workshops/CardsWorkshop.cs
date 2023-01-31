using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal class CardsWorkshop : Workshop<Card>
    {
        public CardsWorkshop(List<Card> pack) : base(pack) { }
        sealed protected override string MaterialChoose()
        {
            return "Choose the card the same quality to upgrade your card";
        }
        sealed protected override bool TryAddAsSource(int materialIndex)
        {
            if (allSources.Count <= Deck.MIN_BATTLE_LIMIT)
            {
                Console.WriteLine($"It is impossible to make merge now.\nYou have to keep at least {Deck.MIN_BATTLE_LIMIT} cards for battle.");
                return false;
            }
            Card material = allSources[EnhancingActiveIndex] as Card;
            Card target = allSources[materialIndex] as Card;
            if (material != null)
            {
                if (material.GetHashCode() == target.GetHashCode() && target.Quality < Quality.Platinum)
                {
                    EnhancingMaterialsIndexes.Add(materialIndex);
                    UpgradeActive();
                    return true;
                }
                else
                    Console.WriteLine("Card have to be the same quality. Choose another card, please.");
            }
            else
            {
                Console.WriteLine("It is not a card. Choose the card, please.");
            }
            return false;
        }
        sealed protected override void TryChooseSources()
        {
            string answer;
            do
            {
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= allSources.Count)
                {
                    if (source[selection - 1].isUsed)
                    {
                        Console.WriteLine("This active already choosen, try another one");
                        continue;
                    }
                    else
                    {
                        bool success = TryAddAsSource(selection - 1);
                        source[selection - 1] = (selection - 1, success);
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                }
            } while (answer != "exit");
        }
        sealed protected override void PrintList()
        {
            allSources.Sort(delegate (Card x, Card y)
            {
                return x.CompareTo(y);
            });
            for (int i = 0; i < allSources.Count; i++)
            {
                var card = allSources[i];
                Console.WriteLine($"{i + 1} - {card.Name,-10} {card.Rareness} {card.Quality} {card.States.Power}", Console.ForegroundColor = card.ChooseColor());
            }
        }
    }
}

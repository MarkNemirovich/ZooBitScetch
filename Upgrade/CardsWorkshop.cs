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
            Card material = AllSources[EnhancingActiveIndex] as Card;
            Card target = AllSources[materialIndex] as Card;
            if (material != null)
            {
                if (material.GetHashCode() == target.GetHashCode() && target.Quality < Quality.Platinum)
                {
                    EnhancingMaterialsIndexes.Add(materialIndex);
                    UpgradeActive();
                    return true;
                }
                else
                    Console.WriteLine("Card have to be the same quality. Choose another card, please");
            }
            else
            {
                Console.WriteLine("It is not a card. Choose the card, please");
            }
            return false;
        }
        sealed protected override void PrintList()
        {
            AllSources.Sort(delegate (Card x, Card y)
            {
                return x.CompareTo(y);
            });
            for (int i = 0; i < AllSources.Count; i++)
            {
                var card = AllSources[i];
                Console.WriteLine($"{i + 1} - {card.Name,-10} {card.Rareness} {card.Quality} {card.States.Power}", Console.ForegroundColor = card.ChooseColor());
            }
        }
    }
}

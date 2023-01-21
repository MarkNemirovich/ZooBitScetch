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
        sealed protected override bool TryAddAsSource(Card source)
        {
            Card target = EnhancingActive as Card;
            Card material = source as Card;
            if (material != null)
            {
                if (material.Guid == target.Guid)
                {
                    EnhancingMaterials.Add(material);
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
            for (int i = 0; i < AllSources.Count; i++)
            {
                var act = AllSources[i];
                Console.WriteLine($"{i + 1} - {act.Name,-10} {act.Rareness} {act.Quality}");
            }
        }
    }
}

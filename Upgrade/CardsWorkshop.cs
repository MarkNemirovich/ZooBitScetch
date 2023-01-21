using System;

namespace ZooBitSketch
{
    internal class CardsWorkshop : Workshop<Card>
    {
        public CardsWorkshop(Card[] pack) : base(pack) { }
        protected override void AddAsSource(Card source)
        {
            Card target = enhancingActive as Card;
            Card material = source as Card;
            if (material != null)
            {
                if (material.Quality == target.Quality)
                {
                    enhancingMaterials.Add(material);
                    UpgradeActive();
                }
            }
            else
            {
                Console.WriteLine("It is not a card. Choose the card, please");
            }
        }
    }
}

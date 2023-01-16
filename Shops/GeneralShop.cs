using System;
using System.Drawing;

namespace ZooBitSketch
{
    internal class GeneralShop : Shop
    {
        public GeneralShop() : base("General Banner", new Box[]
        {   new GeneralBox( 10, Currency.Money, BoxSize.Small ),
            new GeneralBox( 50, Currency.Money, BoxSize.Middle ),
            new GeneralBox( 100, Currency.Money, BoxSize.Large ),
            new GeneralBox( 5, Currency.Diamonds, BoxSize.Small ),
            new GeneralBox( 25, Currency.Diamonds, BoxSize.Middle ),
            new GeneralBox( 50, Currency.Diamonds, BoxSize.Large )
        }) { }
    }
}

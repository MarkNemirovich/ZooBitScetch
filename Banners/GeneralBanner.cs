using System;

namespace ZooBitSketch
{
    internal class GeneralBanner : Banner
    {
        public GeneralBanner() : base(new Box[]
        {   new GeneralBox( 10, Currency.Money, BoxSize.Small ),
            new GeneralBox( 50, Currency.Money, BoxSize.Middle ),
            new GeneralBox( 100, Currency.Money, BoxSize.Large )
        }) { }
    }
}

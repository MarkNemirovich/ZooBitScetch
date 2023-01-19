using System;

namespace ZooBitSketch
{
    internal class CommonBanner : Banner
    {
        public CommonBanner() : base(new Box[]
        {   new CommonBox( 20, Currency.Money, BoxSize.Small ),
            new CommonBox( 50, Currency.Money, BoxSize.Middle ),
            new CommonBox( 100, Currency.Money, BoxSize.Large )
        }) { }

    }
}

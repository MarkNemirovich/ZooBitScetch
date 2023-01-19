using System;

namespace ZooBitSketch
{
    internal class EliteBanner : Banner
    {
        public EliteBanner() : base(new Box[] {
            new EliteBox( 5, Currency.Diamonds, BoxSize.Small ),
            new EliteBox( 25, Currency.Diamonds, BoxSize.Middle ),
            new EliteBox( 100, Currency.Diamonds, BoxSize.Large )
        })
        { }
    }
}

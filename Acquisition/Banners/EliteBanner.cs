using System;
using ZooBitSketch.Acquisition.Boxes;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Acquisition.Banners
{
    internal class EliteBanner : Banner
    {
        public EliteBanner() : base(new Box[] {
            new EliteBox( 20, Currency.Diamonds, BoxSize.Small ),
            new EliteBox( 50, Currency.Diamonds, BoxSize.Middle ),
            new EliteBox( 100, Currency.Diamonds, BoxSize.Large )
        })
        { }
    }
}
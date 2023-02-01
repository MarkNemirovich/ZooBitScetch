using System;
using ZooBitSketch.Acquisition.Boxes;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Acquisition.Banners
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

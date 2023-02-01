using System;
using ZooBitSketch.Acquisition.Boxes;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Acquisition.Banners
{
    internal class GenreBanner : Banner
    {
        public GenreBanner(Genre genre) : base(new Box[] {
            new GenreBox( 40, Currency.Diamonds, BoxSize.Small, genre),
            new GenreBox( 100, Currency.Diamonds, BoxSize.Middle, genre ),
            new GenreBox( 200, Currency.Diamonds, BoxSize.Large, genre )
        })
        { }
    }
}
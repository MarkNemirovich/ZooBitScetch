using System;

namespace ZooBitSketch
{
    internal class FriendBanner : Banner
    {
        public FriendBanner() : base(new Box[]
        {   new FriendBox( 10, Currency.Heart, BoxSize.Small ),
            new FriendBox( 50, Currency.Heart, BoxSize.Middle ),
            new FriendBox( 100, Currency.Heart, BoxSize.Large )
        })
        { }
    }
}

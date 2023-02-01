using System;

namespace ZooBitSketch.Enums
{
    internal enum Chapters
    {
        Tutorial,
        Garage,
        House,
        School,
        College
    }
    [Flags]
    internal enum Terms
    {
        Hidden = 0b0000,
        Open = 0b0001,
        Win = 0b0010,
        Restricted = 0b0100,
        Bonus = 0b1000
    }
    internal enum Conditions
    {
        Euphoria,
        Rounds,
        CardType
    }
}

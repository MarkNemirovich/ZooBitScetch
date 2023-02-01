using System;

namespace ZooBitSketch.Enums
{
    enum Rareness
    {
        Ordinary = 32,
        Rare = 16,
        Elite = 8,
        Epic = 4,
        Legendary = 2
    }
    internal enum Quality
    {
        Bronse,
        Silver,
        Gold,
        Platinum,
        Diamond
    }
    enum Genre
    {
        Universal,
        Rock,
        Rap,
        Pop,
        Reggae
    }
    enum Role
    {
        Universal,
        Singler,
        Guitar,
        Drums,
        Pianist
    }
    enum Phase
    {
        Child = 1,
        Teenager,
        Adult
    }
    enum ClothesType
    {
        Instrument,
        Hat,
        Coat,
        Boots,
        Stone // upgrade material
    }
    internal enum CardType
    {
        Growth,
        Defence,
        Atack,
        Buff,
        Bonus
    }
}
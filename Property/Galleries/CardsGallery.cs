using System;
using System.Collections.Generic;
using ZooBitSketch.Enums;
using ZooBitSketch.Property.Actives;
using ZooBitSketch.Property.Actives.Cards;

namespace ZooBitSketch.Property.Galleries
{
    internal class CardsGallery : Gallery<Card>
    {
        private Card[] Ordinary()
        {
            return new Card[]
            {
            new AtackCard("Atack1", Rareness.Ordinary, Role.Singler,Genre.Rap, RandomStates(Rareness.Ordinary)),
            new BuffCard("Buff1", Rareness.Ordinary, Role.Drums,Genre.Rock, RandomStates(Rareness.Ordinary)),
            new BonusCard("Bonus1", Rareness.Ordinary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Ordinary)),
            new DefenceCard ("Defence1", Rareness.Ordinary, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Ordinary)),
            new GrowthCard("Growth1", Rareness.Ordinary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Ordinary))
            };
        }
        private Card[] Rare()
        {
            return new Card[]
            {
            new AtackCard ("Atack2", Rareness.Rare, Role.Singler, Genre.Rap, RandomStates(Rareness.Rare)),
            new BuffCard("Buff2", Rareness.Rare, Role.Drums,Genre.Rock, RandomStates(Rareness.Rare)),
            new BonusCard("Bonus2", Rareness.Rare, Role.Guitar,Genre.Pop, RandomStates(Rareness.Rare)),
            new DefenceCard ("Defence2", Rareness.Rare, Role.Guitar, Genre.Pop, RandomStates(Rareness.Rare)),
            new GrowthCard("Growth2", Rareness.Rare, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Rare))
         };
        }
        private Card[] Elite()
        {
            return new Card[]
            {
            new AtackCard ("Atack3", Rareness.Elite, Role.Singler, Genre.Rap, RandomStates(Rareness.Elite)),
            new BuffCard("Buff3", Rareness.Elite, Role.Drums,Genre.Rock, RandomStates(Rareness.Elite)),
            new BonusCard("Bonus3", Rareness.Elite, Role.Guitar,Genre.Pop, RandomStates(Rareness.Elite)),
            new DefenceCard ("Defence3", Rareness.Elite, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Elite)),
            new GrowthCard ("Growth3", Rareness.Elite, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Elite))
         };
        }
        private Card[] Epic()
        {
            return new Card[]
            {
            new AtackCard ("Atack4", Rareness.Epic, Role.Singler, Genre.Rap, RandomStates(Rareness.Epic)),
            new BuffCard("Buff4", Rareness.Epic, Role.Drums,Genre.Rock, RandomStates(Rareness.Epic)),
            new BonusCard("Bonus4", Rareness.Epic, Role.Guitar,Genre.Pop, RandomStates(Rareness.Epic)),
            new DefenceCard("Defence4", Rareness.Epic, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Epic)),
            new GrowthCard ("Growth4", Rareness.Epic, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Epic))
         };
        }
        private Card[] Legendary()
        {
            return new Card[]
            {
            new AtackCard ("Atack5", Rareness.Legendary, Role.Singler, Genre.Rap, RandomStates(Rareness.Legendary)),
            new BuffCard("Buff5", Rareness.Legendary, Role.Drums,Genre.Rock, RandomStates(Rareness.Legendary)),
            new BonusCard("Bonus5", Rareness.Legendary, Role.Guitar,Genre.Pop, RandomStates(Rareness.Legendary)),
            new DefenceCard("Defence5", Rareness.Legendary, Role.Pianist,Genre.Reggae, RandomStates(Rareness.Legendary)),
            new GrowthCard ("Growth5", Rareness.Legendary, Role.Pianist, Genre.Reggae, RandomStates(Rareness.Legendary))
            };
        }
        public CardsGallery(Rareness rareness) : base()
        {
            allActives.TryAdd(Rareness.Ordinary, Ordinary());
            allActives.TryAdd(Rareness.Rare, Rare());
            allActives.TryAdd(Rareness.Elite, Elite());
            allActives.TryAdd(Rareness.Epic, Epic());
            allActives.TryAdd(Rareness.Legendary, Legendary());
            allActives.TryGetValue(rareness, out Card[] currentPack);
            CurrentPack = currentPack;
        }
    }
}

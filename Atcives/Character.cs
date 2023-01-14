using System;

namespace ZooBitSketch
{
    internal class Character
    {
        public string Name { get; private set; }
        public float Power { get; private set; }
        public float Initiative { get; private set; }
        public float Fame { get; private set; }
        public float Artistry { get; private set; }
        public float Charisma { get; private set; }
        public float Virtuosity { get; private set; }
        public Phase Phase { get; private set; }
        public readonly Rareness Rareness;
        public readonly Class Class;
        public readonly Genre Genre;

        public Character(string name, float initiative, float fame, float artistry, float charisma, float virtuosity, Phase phase, Rareness rareness, Class @class, Genre genre)
        {
            Name = name;
            Initiative= initiative;
            Fame= fame;
            Artistry= artistry;
            Charisma= charisma;
            Virtuosity= virtuosity;
            Phase = phase;
            Rareness = rareness;
            Class = @class;
            Genre = genre;
            Power = CalculatePower();
        }

        private float CalculatePower()
        {
            return (Initiative/2 + Fame + Artistry + Charisma + Virtuosity) * (int)Phase;
        }
        public string Info()
        {
            return $"\nName: {Name}\n\tStates:\nPower: {Power}\nInitiative: {Initiative}\nFame: {Fame}\n" +
                $"Artistry: {Artistry}\nCharisma: {Charisma}\nVirtuosity: {Virtuosity}\n" +
                $"\tPerforms:\nPhase: {Phase.ToString()}\nRareness: {Rareness.ToString()}\nClass: {Class.ToString()}\nGenre: {Genre.ToString()}\n";
        }
    }
}

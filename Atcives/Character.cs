using System;

namespace ZooBitSketch
{
    internal class Character
    {
        public string Name { get; private set; }
        public double Power { get; private set; }
        public double Initiative { get; private set; }
        public double Fame { get; private set; }
        public double Artistry { get; private set; }
        public double Charisma { get; private set; }
        public double Virtuosity { get; private set; }
        public Phase Phase { get; private set; }
        public readonly Rareness Rareness;
        public readonly Class Class;
        public readonly Genre Genre;

        public Character(string name, double initiative, double fame, double artistry, double charisma, double virtuosity, Phase phase, Rareness rareness, Class @class, Genre genre)
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

        private double CalculatePower()
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

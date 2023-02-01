using System;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.Actives
{
    internal class States
    {
        private static Random rand = new Random();
        public double Power { get; private set; }
        public double Initiative { get; private set; }
        public double Fame { get; private set; }
        public double Artistry { get; private set; }
        public double Charisma { get; private set; }
        public double Virtuosity { get; private set; }
        public States(Rareness rareness)
        {
            double multyplayer= (double)Rareness.Ordinary/(double)rareness;
            Initiative = rand.Next(10,100) * multyplayer;
            Fame = rand.Next(10, 100) * multyplayer;
            Artistry = rand.Next(10, 100) * multyplayer;
            Charisma = rand.Next(10, 100) * multyplayer;
            Virtuosity = rand.Next(10, 100) * multyplayer;
            Power = 0;
            CalculatePower();
        }
        public void CalculatePower()
        {
            Power = (Initiative / 2 + Fame + Artistry + Charisma + Virtuosity);
        }
        public void Evolve(double multiplayer)
        {
            Initiative *= multiplayer;
            Fame *= multiplayer;
            Artistry *= multiplayer;
            Charisma *= multiplayer;
            Virtuosity *= multiplayer;
        }
        public string Info()
        {
            return $"Power: {Power}\nInitiative: {Initiative,-5}Fame: {Fame,-5}\t" +
                $"Artistry: {Artistry,-5}Charisma: {Charisma,-5}Virtuosity: {Virtuosity,-5}";
        }
    }
}

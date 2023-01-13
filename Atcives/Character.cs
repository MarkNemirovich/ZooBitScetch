using System;

namespace ZooBitScetch
{
    internal class Character
    {
        public string Name{ get; private set; }
        public float Power { get; private set; }
        public float Initiative { get; private set; }
        public float Fame { get; private set; }
        public float Artistry { get; private set; }
        public float Charisma { get; private set; }
        public float Virtuosity { get; private set; }
        public Phase Phase { get; private set; }

        public readonly Class Class;
        public readonly Genre Genre;
        public readonly Rareness Rareness;

        private void CalculatePower()
        {
            Power = (Initiative/2 + Fame + Artistry + Charisma + Virtuosity) * (int)Phase;
        }
    }
}

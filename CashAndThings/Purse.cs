using System;

namespace ZooBitSketch
{
    internal class Purse
    {
        public uint Money { get; private set; }
        public uint Diamonds { get; private set; }
        public uint DNA { get; private set; }
        public Purse()
        {
            Money = 1000;
            Diamonds = 0;
            DNA = 0;
        }
        public void Info()
        {
            Console.WriteLine($"Money = {Money}\nDiamonds = {Diamonds}\nDNA = {DNA}\n\nPress any key for continue...");
            Console.ReadKey();
        }
    }
}

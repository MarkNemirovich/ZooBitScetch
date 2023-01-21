﻿using System;

namespace ZooBitSketch
{
    internal class Bag
    {
        public int Stone { get; private set; }
        public int Dust { get; private set; }
        public void Info()
        {
            Console.WriteLine($"Stone is {Stone}\nPress any key for exit...");
            Console.ReadKey();
        }
        public void AddSurplusEnhanceMaterial(int material)
        {
            Stone += material;
        }
    }
}
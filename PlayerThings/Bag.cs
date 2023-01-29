using System;
using System.Collections.Generic;

namespace ZooBitSketch.Player
{
    internal class Bag
    {
        private static readonly Lazy<Bag> lazy = new Lazy<Bag>(() => new Bag());
        private Dictionary<Resources, int> resources;
        private Bag()
        {
            resources = new Dictionary<Resources, int>();
            resources.TryAdd(Resources.Stone, 1000);
            resources.TryAdd(Resources.Dust, 1000);
        }
        public static Bag GetInstance()
        {
            return lazy.Value;
        }
        public void Info()
        {
            string data = string.Empty;
            foreach (var pair in resources)
            {
                data += $"{pair.Key.ToString()} = {pair.Value}\n";
            }
            Console.WriteLine($"{data}Press any key for continue...");
            Console.ReadKey();
        }
        public void AddSurplusEnhanceMaterial(int material)
        {
            if (resources.TryGetValue(Resources.Stone, out int Stone))
                resources[Resources.Stone] += material;
        }
    }
}
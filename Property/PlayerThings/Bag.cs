using System;
using System.Collections.Generic;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Property.PlayerThings
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
        public void AddSurplusEnhanceMaterial((Resources material, int amount) resource)
        {
            if (resources.TryGetValue(resource.material, out int amount))
                resources[resource.material] += resource.amount;
        }
    }
}
using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal abstract class Workshop<T> where T : Active
    {
        public readonly string Name;
        protected List<(T active, bool isChoosen)> AllSources;
        public Active enhancingActive { get; protected set; }
        public List<Active> enhancingMaterials { get; protected set; }
        public Workshop(T[] pack)
        {
            for (int i = 0; i < pack.Length; i++)
            {
                AllSources.Add((pack[i], false));
            }
            Info();
            string answer;
            while (true)
            {
                answer = Console.ReadLine();
                if (answer != "exit")
                    break;
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection < AllSources.Count)
                {
                    ChooseActive(AllSources[selection - 1].active);
                    AllSources[selection - 1].isChoosen = true;
                }
                else
                {
                    Console.WriteLine("No active with such number. Check your input\nPress any key for continue...");
                    Console.ReadKey();
                }
            }
        }
        public void ChooseActive(T baseActive)
        {
            enhancingActive = baseActive;
        }
        protected virtual void UpgradeActive()
        {
            enhancingActive.Evolve();
            foreach(var Active in enhancingMaterials)
                Active.Sacrifice();
        }
        protected virtual void AddAsSource(T material)
        {
            enhancingMaterials.Add(material);
        }
        public virtual void Info()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {this.GetType().ToString().ToLower()}. Select the item you want to upgrade. For exit write \"exit\"");
            PrintList();
            Console.ReadLine();
        }
        protected virtual void PrintList()
        {
            for (int i = 0; i < AllSources.Count; i++)
            {
                var act = AllSources[i].active;
                Console.WriteLine($"{i+1} - {act.Name,-10} {act.Rareness}");
            }
        }
    }
}

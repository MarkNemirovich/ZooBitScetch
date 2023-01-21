using System;
using System.Collections.Generic;

namespace ZooBitSketch
{
    internal abstract class Workshop<T> where T : Active
    {
        public readonly string Name;
        protected List<T> AllSources;
        protected (int indexInThePack, bool isUsed)[] Source;
        public Active EnhancingActive { get; protected set; }
        public List<Active> EnhancingMaterials { get; protected set; }
        public Workshop(List<T> pack)
        {
            AllSources= pack;
            EnhancingMaterials = new List<Active>();
            Source = new (int, bool)[AllSources.Count];
            Info();
            string answer;
            while (true)
            {
                answer = Console.ReadLine();
                if (answer == "exit")
                    break;
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection < AllSources.Count)
                {
                    ChooseActive(AllSources[selection - 1]);
                    Source[selection - 1] = (selection - 1, true);
                    Console.WriteLine($"{MaterialChoose()}\nPress \"fin\" for finish");
                    do
                    {
                        answer = Console.ReadLine();
                        if (Int32.TryParse(answer, out selection) && selection > 0 && selection < AllSources.Count)
                        {
                            if (Source[selection - 1].isUsed)
                            {
                                Console.WriteLine("This active already choosen, try another one");
                                continue;
                            }
                            else
                            {
                                bool success = TryAddAsSource(AllSources[selection - 1]);
                                Source[selection - 1] = (selection - 1, true);
                            }
                        }
                    } while (answer != "fin");
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
            EnhancingActive = baseActive;
        }
        protected virtual void UpgradeActive()
        {
            EnhancingActive.Evolve();
            foreach (var Active in EnhancingMaterials)
                Active.Sacrifice();
        }
        protected virtual bool TryAddAsSource(T material)
        {
            EnhancingMaterials.Add(material);
            return true;
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
                var act = AllSources[i];
                Console.WriteLine($"{i + 1} - {act.Name,-10} {act.Rareness}");
            }
        }
        protected virtual string MaterialChoose()
        {
            return "Choose the cards to upgrade your card";
        }
    }
}

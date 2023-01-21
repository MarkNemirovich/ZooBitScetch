using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace ZooBitSketch
{
    internal abstract class Workshop<T> where T : Active
    {
        public readonly string Name;
        protected List<T> AllSources;
        protected (int indexInThePack, bool isUsed)[] Source;
        public int EnhancingActiveIndex { get; protected set; }
        public List<int> EnhancingMaterialsIndexes { get; protected set; }
        public Workshop(List<T> pack)
        {
            AllSources = pack;
        }

        public void Enhance()
        {
            string answer;
            while (true)
            {
                Info();
                EnhancingMaterialsIndexes = new List<int>();
                Source = new (int, bool)[AllSources.Count];
                answer = Console.ReadLine();
                if (answer == "exit")
                    break;
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= AllSources.Count)
                {
                    if (ChooseActive(selection - 1))
                    {
                        Source[selection - 1] = (selection - 1, true);
                        Console.WriteLine($"{MaterialChoose()}\nPress \"exit\" for finish");
                        TryChooseSources();
                    }
                }
                else
                {
                    Console.WriteLine("No active with such number. Check your input\nPress any key for continue...");
                    Console.ReadKey();
                }
            }
        }
        protected virtual bool ChooseActive(int baseActiveIndex)
        {
            EnhancingActiveIndex = baseActiveIndex;
            return true;
        }
        protected abstract void TryChooseSources();
        protected virtual void UpgradeActive()
        {
            AllSources[EnhancingActiveIndex].Evolve();
            EnhancingMaterialsIndexes.Sort();
            for (int i = EnhancingMaterialsIndexes.Count-1; i >= 0; i--) // delete from the end, because shift would change indexes
            {
                AllSources[EnhancingMaterialsIndexes[i]].Sacrifice();
            }
        }
        protected virtual bool TryAddAsSource(int materialIndex)
        {
            EnhancingMaterialsIndexes.Add(materialIndex);
            return true;
        }
        public virtual void Info()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {this.GetType().ToString().ToLower()}.\nSelect the item you want to upgrade. For exit write \"exit\"");
            PrintList();
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected virtual void PrintList()
        {
            for (int i = 0; i < AllSources.Count; i++)
            {
                var act = AllSources[i];
                Console.WriteLine($"{i + 1} - {act.Name,-10} {act.Rareness} {act.States.Power,-10}", Console.ForegroundColor = act.ChooseColor());
            }
        }
        protected virtual string MaterialChoose()
        {
            return "Choose the cards to upgrade your card";
        }
    }
}
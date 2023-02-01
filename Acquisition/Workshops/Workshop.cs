using System;
using System.Collections.Generic;
using System.Diagnostics;
using ZooBitSketch.Property.Actives;

namespace ZooBitSketch.Acquisition.Workshops
{
    internal abstract class Workshop<T> where T : Active
    {
        public readonly string Name;
        public int EnhancingActiveIndex { get; protected set; }
        public List<int> EnhancingMaterialsIndexes { get; protected set; }
        protected List<T> allSources;
        protected (int indexInThePack, bool isUsed)[] source;
        public Workshop(List<T> pack)
        {
            allSources = pack;
        }
        public void Enhance()
        {
            string answer;
            while (true)
            {
                Info();
                EnhancingMaterialsIndexes = new List<int>();
                source = new (int, bool)[allSources.Count];
                answer = Console.ReadLine();
                if (answer == "exit")
                    break;
                if (int.TryParse(answer, out int selection) && selection > 0 && selection <= allSources.Count)
                {
                    source[selection - 1] = (selection - 1, true);
                    Console.WriteLine($"{MaterialChoose()}\nPress \"exit\" for finish");
                    TryChooseSources();
                }
                else
                {
                    Console.WriteLine("No active with such number. Check your input\nPress any key for continue...");
                    Console.ReadKey();
                }
            }
        }
        protected abstract void TryChooseSources();
        protected virtual void UpgradeActive()
        {
            allSources[EnhancingActiveIndex].Evolve();
            EnhancingMaterialsIndexes.Sort();
            for (int i = EnhancingMaterialsIndexes.Count - 1; i >= 0; i--) // delete from the end, because shift would change indexes
            {
                allSources[EnhancingMaterialsIndexes[i]].Sacrifice();
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
            Console.WriteLine($"Welcome to the {GetType().ToString().ToLower()}.\nSelect the item you want to upgrade. For exit write \"exit\"");
            PrintList();
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected virtual void PrintList()
        {
            for (int i = 0; i < allSources.Count; i++)
            {
                var act = allSources[i];
                Console.WriteLine($"{i + 1} - {act.Name,-10} {act.Rareness} {act.States.Power,-10}", Console.ForegroundColor = act.ChooseColor());
            }
        }
        protected virtual string MaterialChoose()
        {
            return "Choose the cards to upgrade your card";
        }
    }
}
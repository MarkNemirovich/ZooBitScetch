using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace ZooBitSketch
{
    internal class Smithy : Workshop<Clothes>
    {
        public Smithy(List<Clothes> pack) : base(pack) { }
        public Action<int> EnhenceSurplus;
        protected override void PrintList()
        {
            for (int i = 0; i < AllSources.Count; i++)
            {
                var act = AllSources[i];
                Console.WriteLine($"{i} - {act.Name,-10} {act.Rareness,-10} {act.Genre,-10}");
            }
        }
        sealed protected override bool TryAddAsSource(int materialIndex)
        {
            Clothes material = AllSources[EnhancingActiveIndex] as Clothes;
            Clothes target = AllSources[materialIndex] as Clothes; EnhancingMaterialsIndexes.Add(materialIndex);
            return (material.PartType == target.PartType);
        }
        sealed protected override void TryChooseSources()
        {
            string answer;
            int materialExp = 0;
            int cost = AllSources[EnhancingActiveIndex].EnhanceCost;
            do
            {
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= AllSources.Count)
                {
                    if (Source[selection - 1].isUsed)
                    {
                        Console.WriteLine("This active already choosen, try another one");
                        continue;
                    }
                    else
                    {
                        bool success = TryAddAsSource(selection - 1);
                        Source[selection - 1] = (selection - 1, true);
                        Clothes material = AllSources[EnhancingActiveIndex] as Clothes;
                        if (success)
                            materialExp += 2*material.CalculateEnhanceCost();
                        else
                            materialExp += material.CalculateEnhanceCost();
                        if (materialExp >= cost)
                        {
                            EnhenceSurplus?.Invoke(materialExp - cost);
                            UpgradeActive();
                        }
                    }
                }
            } while (answer != "exit");
        }
    }
}
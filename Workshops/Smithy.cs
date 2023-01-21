using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace ZooBitSketch
{
    internal class Smithy : Workshop<Clothes>
    {
        public Smithy(List<Clothes> pack) : base(pack) { }
        public Action<int> EnhenceSurplus;
        sealed protected override bool TryAddAsSource(int materialIndex)
        {
            Clothes material = AllSources[EnhancingActiveIndex] as Clothes;
            Clothes target = AllSources[materialIndex] as Clothes;
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
                    if (selection - 1 == EnhancingActiveIndex)
                    {
                        Console.WriteLine("You cannot to use this object for upgrate itself.");
                        continue;
                    }
                    else
                    {
                        bool success = TryAddAsSource(selection - 1);
                        Source[selection - 1] = (selection - 1, !Source[selection - 1].isUsed);
                        Clothes material = AllSources[selection - 1] as Clothes;
                        if (Source[selection - 1].isUsed)
                        {
                            if (success)
                                materialExp += 2 * material.CalculateEnhanceCost();
                            else
                                materialExp += material.CalculateEnhanceCost();
                            EnhancingMaterialsIndexes.Add(selection - 1);
                        }
                        else
                        {
                            if (success)
                                materialExp -= 2 * material.CalculateEnhanceCost();
                            else
                                materialExp -= material.CalculateEnhanceCost();
                            EnhancingMaterialsIndexes.Remove(selection - 1);
                        }
                        if (materialExp >= cost)
                        {
                            EnhenceSurplus?.Invoke(materialExp - cost);
                            UpgradeActive();
                        }
                        Console.WriteLine($"You filled {materialExp}/{cost} enhanceExp");
                    }
                }
            } while (answer != "exit");
        }
        protected override bool ChooseActive(int baseActiveIndex)
        {
            if ((AllSources[baseActiveIndex] as Clothes).PartType == ClothesType.Stone)
            {
                Console.WriteLine("Stone cannot be enhances. Choose wearable clothes");
                return false;
            }
            EnhancingActiveIndex = baseActiveIndex;
            return true;
        }
        sealed protected override void PrintList()
        {
            AllSources.Sort(delegate (Clothes x, Clothes y)
            {
                return x.CompareTo(y);
            });
            for (int i = 0; i < AllSources.Count; i++)
            {
                var clothes = AllSources[i];
                Console.WriteLine($"{i+1} - {clothes.Name,-10} {clothes.Rareness,-10} {clothes.Genre,-10} Enhance-{clothes.EnhanceLevel,-10} {clothes.States.Power,-10}", Console.ForegroundColor = clothes.ChooseColor());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using ZooBitSketch.Enums;
using ZooBitSketch.Property.Actives.Clothes;

namespace ZooBitSketch.Acquisition.Workshops
{
    internal class Smithy : Workshop<Clothes>
    {
        public Smithy(List<Clothes> pack) : base(pack) { }
        public Action<int> EnhenceSurplus;
        sealed protected override bool TryAddAsSource(int materialIndex)
        {
            Clothes material = allSources[EnhancingActiveIndex];
            Clothes target = allSources[materialIndex];
            return material.GetType().Equals(target.GetType());
        }
        sealed protected override void TryChooseSources()
        {
            string answer;
            int materialExp = 0;
            int cost = allSources[EnhancingActiveIndex].EnhanceCost;
            do
            {
                answer = Console.ReadLine();
                if (int.TryParse(answer, out int selection) && selection > 0 && selection <= allSources.Count)
                {
                    if (selection - 1 == EnhancingActiveIndex)
                    {
                        Console.WriteLine("You cannot to use this object for upgrate itself.");
                        continue;
                    }
                    else
                    {
                        bool success = TryAddAsSource(selection - 1);
                        source[selection - 1] = (selection - 1, !source[selection - 1].isUsed);
                        Clothes material = allSources[selection - 1] as Clothes;
                        if (source[selection - 1].isUsed)
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
        sealed protected override void PrintList()
        {
            allSources.Sort(delegate (Clothes x, Clothes y)
            {
                return x.CompareTo(y);
            });
            for (int i = 0; i < allSources.Count; i++)
            {
                var clothes = allSources[i];
                Console.WriteLine($"{i + 1} - {clothes.Name,-10} {clothes.Rareness,-10} {clothes.Genre,-10} Enhance-{clothes.EnhanceLevel,-10} {clothes.States.Power,-10}", Console.ForegroundColor = clothes.ChooseColor());
            }
        }
    }
}
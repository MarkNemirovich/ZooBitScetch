using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;

namespace ZooBitSketch.Story
{
    internal class Chapter
    {
        public readonly string Name;
        public bool IsCleared { get; private set; }
        public bool IsComplited { get; private set; }
        public Stage[] Stages { get; private set; }
        public Stage CurrentStage => Stages[currentStageIndex];
        private int currentStageIndex;
        private int starsCurrentAmount;
        private int starsMaxAmount;
        public Chapter(string name, Stage[] stages)
        {
            Name = name;
            Stages = stages;
            currentStageIndex = 0;
            Stages[currentStageIndex].ChangeEnableMode(Terms.Open);
            starsCurrentAmount = 0;
            starsMaxAmount = stages.Length * 3;

            CurrentStage.StageStarted += OnStageStarted;
            CurrentStage.StageComplited += OnStageCompliting;
            CurrentStage.StageCleared += OnStageCleared;
        }
        public void SelectStage()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the stage from the list:");
                for (int i = 0; i < Stages.Length; i++)
                {
                    Console.WriteLine($"{i + 1} {Stages[i].Info()}");
                }
                Console.WriteLine("For exit write \"exit\"");
                string answer = Console.ReadLine();
                if (answer.Equals("exit"))
                    return;
                if (int.TryParse(answer, out int selectedIndex))
                {
                    currentStageIndex = selectedIndex - 1;
                    Console.WriteLine(Stages[currentStageIndex].TermsDescription);
                    Console.WriteLine("Do you want to start this battle?");
                    Console.ReadKey();
                }
            }
        }
        public string Info()
        {
            return $"{Name} is completed by {starsCurrentAmount}/{starsMaxAmount} {(starsCurrentAmount == starsMaxAmount ? "Cleared" : "")}";
        }
        private void OnStageCompliting()
        {
            if (currentStageIndex == Stages.Length)
            {
                IsCleared = true;
                IsComplited = starsCurrentAmount == starsMaxAmount;
            }
            Stages[currentStageIndex + 1].ChangeEnableMode(Terms.Open);
        }
        private void OnStageStarted()
        {
            starsCurrentAmount -= CurrentStage.Stars & (int)(Terms.Win & Terms.Restricted & Terms.Bonus); // Flag mask
        }
        private void OnStageCleared()
        {
            starsCurrentAmount += CurrentStage.Stars & (int)(Terms.Win & Terms.Restricted & Terms.Bonus); // Flag mask
        }

    }
}

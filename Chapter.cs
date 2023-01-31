using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBitSketch
{
    internal class Chapter
    {
        public readonly string Name;
        public Stage[] Stages { get; private set; }
        public Stage CurrentChapter => Stages[currentStageIndex];
        private int currentStageIndex;
        private int starsCurrentAmount;
        private int starsMaxAmount;
        public Chapter(string name, Stage[] stages)
        {
            Name = name;
            Stages = stages;
            currentStageIndex = -1;
            starsCurrentAmount = 0;
            starsMaxAmount = stages.Length*3;
        }
    }
}

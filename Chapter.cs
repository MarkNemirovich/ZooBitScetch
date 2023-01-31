using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBitSketch
{
    internal class Chapter
    {
        public readonly string Name;
        public Stage[] Stages { get; private set; }
        private int currentStageIndex;
        public Stage CurrentChapter => Stages[currentStageIndex];
        public Chapter(string name, Stage[] stages)
        {
            Name = name;
            Stages = stages;
            currentStageIndex = -1;
        }
    }
}

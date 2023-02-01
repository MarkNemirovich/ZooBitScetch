using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.Story.StageFactory;

namespace ZooBitSketch.Story.ChapterFactory
{
    internal class ChapterTutorialFactory : ChapterAbstractFactory
    {
        public ChapterTutorialFactory() : base(Chapters.Tutorial)
        {
            stageFactory = new StageTutorialFactory();
        }
    }
}

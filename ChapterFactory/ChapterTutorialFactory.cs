using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.StageFactory;

namespace ZooBitSketch.ChapterFactory
{
    internal class ChapterTutorialFactory : ChapterAbstractFactory
    {
        public ChapterTutorialFactory() : base(Chapters.Tutorial)
        {
            stageFactory = new StageTutorialFactory();
        }
    }
}

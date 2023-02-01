using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.Story.StageFactory;

namespace ZooBitSketch.Story.ChapterFactory
{
    internal class ChapterOneFactory : ChapterAbstractFactory
    {
        public ChapterOneFactory() : base(Chapters.Garage)
        {
            stageFactory = new StageOneFactory();
        }
    }
}

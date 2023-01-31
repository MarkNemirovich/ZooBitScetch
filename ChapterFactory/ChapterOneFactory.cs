using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.StageFactory;

namespace ZooBitSketch.ChapterFactory
{
    internal class ChapterOneFactory : ChapterAbstractFactory
    {
        public ChapterOneFactory() : base(Chapters.Garage)
        {
            stageFactory = new StageOneFactory();
        }
    }
}

using System;
using ZooBitSketch.Enums;
using ZooBitSketch.StageFactory;

namespace ZooBitSketch.ChapterFactory
{
    internal abstract class ChapterAbstractFactory
    {
        protected StageAbstractFactory stageFactory;
        private readonly Chapters chapter;
        public ChapterAbstractFactory(Chapters chapter)
        {
            this.chapter = chapter;
        }
        public virtual Chapter CreateChapter() => new Chapter(chapter.ToString(), stageFactory.CreateStages());
    }
}

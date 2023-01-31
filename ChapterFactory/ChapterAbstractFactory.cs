using System;
using ZooBitSketch.Enums;
using ZooBitSketch.StageFactory;

namespace ZooBitSketch.ChapterFactory
{
    internal abstract class ChapterAbstractFactory
    {
        protected StageAbstractFactory stageFactory;
        private readonly Chapters chapter;
        private readonly int stagesAmount;
        public ChapterAbstractFactory(Chapters chapter)
        {
            this.chapter = chapter;
            stagesAmount = 5 * ((int)this.chapter + 1);
        }
        public virtual Chapter CreateChapter()
        {
            Stage[] stages = new Stage[stagesAmount];
            for (int i = 0; i < stagesAmount; i++)
                stages[i] = stageFactory.CreateStage(i);
            return new Chapter(chapter.ToString(), stages);
        }
    }
}

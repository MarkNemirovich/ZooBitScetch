using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.ChapterFactory;
namespace ZooBitSketch
{
    internal class Story
    {
        private Lazy<Story> instance = new Lazy<Story>(() => new Story());
        private List<Chapter> openedChapters;
        private Chapters currentChapter;
        private Story()
        {
            currentChapter = Chapters.Tutorial;
            openedChapters = new List<Chapter>();
            openedChapters.Add(new ChapterTutorialFactory().CreateChapter());
        }
        public Story GetInstance() => instance.Value;
        public Chapter CurrentChapter => openedChapters[(int)currentChapter];
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ZooBitSketch
{
    internal class Story
    {
        private Lazy<Story> instance = new Lazy<Story>(() => new Story());
        private Chapter[] chapters;
        private int currentChapterIndex = -1;
        private Story()
        {
        }
        public Story GetInstance() => instance.Value;
        public Chapter CurrentChapter => chapters[currentChapterIndex];
    }
}

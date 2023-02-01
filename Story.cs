using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.ChapterFactory;
namespace ZooBitSketch
{
    internal class Story
    {
        private static Lazy<Story> instance = new Lazy<Story>(() => new Story());
        private List<Chapter> openedChapters;
        private Chapter currentChapter;
        private Story()
        {
            openedChapters = new List<Chapter>();
            openedChapters.Add(new ChapterTutorialFactory().CreateChapter());
        }
        public static Story GetInstance() => instance.Value;

        public void SelectChapter()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Choose the chapter from the list:");
                for (int i = 0; i < openedChapters.Count; i++)
                {
                    Console.WriteLine($"{i + 1} {openedChapters[i].Info()}");
                }
                Console.WriteLine("For exit write \"exit\"");
                string answer = Console.ReadLine();
                if (answer.Equals("exit"))
                    return;
                if (Int32.TryParse(answer, out int selectedIndex))
                {
                    currentChapter = openedChapters[selectedIndex - 1];
                    currentChapter.SelectStage();
                }
            }
        }
    }
}

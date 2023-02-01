using System;
using System.Collections.Generic;
using System.Text;
using ZooBitSketch.Enums;
using ZooBitSketch.Story.ChapterFactory;

namespace ZooBitSketch.Story
{
    internal class MainStory
    {
        private static Lazy<MainStory> instance = new Lazy<MainStory>(() => new MainStory());
        private List<Chapter> openedChapters;
        private Chapter currentChapter;
        private MainStory()
        {
            openedChapters = new List<Chapter>();
            openedChapters.Add(new ChapterTutorialFactory().CreateChapter());
        }
        public static MainStory GetInstance() => instance.Value;

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
                if (int.TryParse(answer, out int selectedIndex))
                {
                    currentChapter = openedChapters[selectedIndex - 1];
                    currentChapter.SelectStage();
                }
            }
        }
    }
}

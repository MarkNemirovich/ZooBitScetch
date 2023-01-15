using System;

namespace ZooBitSketch
{
    internal abstract class Shop
    {
        protected readonly Box[] Boxes;
        public string Name { get; private set; }
        protected Shop(string name, Box[] boxes)
        {
            Name = name;
            Boxes = boxes;
        }
        private void WriteList()
        {
            Console.Clear();
            Console.WriteLine($"We have 6 boxes:\nWhat box do you interested in?\nFor exit write \"exit.\"");
            for (int i = 1; i <= Boxes.Length; i++)
                Console.WriteLine($"{i} - {Boxes[i - 1].Name()}");
        }
    }
}

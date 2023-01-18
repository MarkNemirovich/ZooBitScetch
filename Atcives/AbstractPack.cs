using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;

namespace ZooBitSketch
{
    internal abstract class AbstractPack<T> where T : Active
    {
        public string Name { get; private set; }
        public List<T> Pack { get; private set; }
        protected AbstractPack(int size)
        {
            Name = typeof(T).Name; 
            Pack = new List<T>(size);
        }
        public virtual void Info()
        {
            string request;
            do
            {
                WriteList();
                request = Console.ReadLine();
                if (Int32.TryParse(request, out int result) && result > 0 && result <= Pack.Count)
                {
                    string text = Pack[result - 1].Info();
                    Console.WriteLine(text, Console.ForegroundColor = Pack[result - 1].ChooseColor());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key for continue...");
                    Console.ReadKey();
                }
                else if (request != "exit")
                {
                    Console.WriteLine("No character with such number. Check your input\nPress any key for continue...");
                    Console.ReadKey();
                }
            } while (request != "exit");
        }
        protected virtual void WriteList()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} deck.");
        }
        public virtual void Add(T newItem)
        {
            Pack.Add(newItem);
            Console.WriteLine(newItem.Info());
        }
    }
}

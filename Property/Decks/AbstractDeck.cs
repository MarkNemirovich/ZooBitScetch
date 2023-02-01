using System;
using System.Collections.Generic;
using ZooBitSketch.Property.Actives;

namespace ZooBitSketch.Property.Decks
{
    internal abstract class AbstractDeck<T> where T : Active
    {
        public string Name { get; private set; }
        public List<T> Pack { get; private set; }
        protected AbstractDeck(int size)
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
                if (int.TryParse(request, out int result) && result > 0 && result <= Pack.Count)
                {
                    string text = Pack[result - 1].Info();
                    Console.WriteLine(text, Console.ForegroundColor = Pack[result - 1].ChooseColor());
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\nPress any key for continue...");
                    Console.ReadKey();
                }
                else if (request != "exit")
                {
                    Console.WriteLine("No active with such number. Check your input\nPress any key for continue...");
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
            newItem.SacrificeMe += Remove;
            Console.WriteLine(newItem.Info());
        }
        protected abstract void Remove(object newItem);
    }
}

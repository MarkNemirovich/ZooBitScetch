using System;
using System.Collections.Generic;
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
                Console.WriteLine("It is empty yet.\nPress any key for continue...");
                Console.ReadKey();
            } while (request != "exit");
        }
        protected virtual void WriteList()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} deck.");
        }
        protected virtual void Add(T newItem)
        {
            Pack.Add(newItem);
        }
    }
}

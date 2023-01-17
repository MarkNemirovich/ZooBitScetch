using System;
using System.Collections.Generic;
using System.Drawing;

namespace ZooBitSketch
{
    internal abstract class AbstractPack<T> where T : Active
    {
        public string Name { get; private set; }
        public List<T> Team { get; private set; }
        protected AbstractPack(int size)
        {
            Name = typeof(T).Name; 
            Team = new List<T>(size);
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
        protected virtual void Add()
        {
            
        }
    }
}

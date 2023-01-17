using System;

namespace ZooBitSketch
{
    internal abstract class AbstractPack<T> where T : Active
    {
        public string Name { get; private set; }
        protected AbstractPack()
        {
            Name = typeof(T).Name;
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
    }
}

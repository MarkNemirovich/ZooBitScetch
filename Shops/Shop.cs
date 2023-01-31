using System;
using System.Collections.Generic;
using ZooBitSketch.Player;
using ZooBitSketch.PlayerThings;

namespace ZooBitSketch
{
    internal abstract class Shop<T> where T : Active
    {
        public virtual string Name { get; protected set; }
        public List<(T active, int price, Currency currency)> Actives { get; protected set; }
        public Shop()
        {
            Name = this.GetType().ToString();
        }
        public void Entry(ICustomer customer)
        {
            Info();
            string answer;
            do
            {
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= Actives.Count)
                {
                    Purchase(customer, selection - 1);
                }
                else
                {
                    Console.WriteLine("No active with such number. Try again");
                }
            } while (answer != "exit");
        }
        private void Purchase(ICustomer customer, int index)
            {
            var selectedActive = Actives[index];
            if (customer.Purchase(selectedActive.currency, selectedActive.price))
            {
                customer.AddActive(selectedActive.active);
                Actives.RemoveAt(index);
                Info();
            }
            else
                Console.WriteLine($"You have not enough {selectedActive.currency}");
        }
        protected virtual void Info()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name.ToLower()}.\nSelect the item you want to purchase. For exit write \"exit\"");
            PrintList();
            Console.ForegroundColor = ConsoleColor.White;
        }
        protected virtual void PrintList()
        {
            for (int i = 0; i < Actives.Count; i++)
            {
                var act = Actives[i];
                Console.ForegroundColor = act.active.ChooseColor();
                Console.WriteLine($"{i + 1} - {act.active.Name,-10} {act.active.Rareness} {act.active.States.Power,-10} {act.price,-10} {act.currency,-10}");
            }
        }
    }
}

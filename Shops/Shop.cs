using System;
using System.Collections.Generic;
using ZooBitSketch.Player;

namespace ZooBitSketch
{
    internal abstract class Shop<T> where T : Active
    {
        public abstract string Name { get; protected set; }
        public List<(T active, int price, Currency currency)> Actives { get; protected set; }
        public void Entry(PlayerEntity customer)
        {
            Info();
            string answer;
            do
            {
                answer = Console.ReadLine();
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= Actives.Count)
                {
                    var selectedActive = Actives[selection - 1];
                    if (customer.Wallet.Pay(selectedActive.currency, selectedActive.price))
                    {
                        FillThePack(customer, selectedActive.active);
                        Actives.RemoveAt(selection - 1);
                        Info();
                    }
                    else
                        Console.WriteLine($"You have not enough {selectedActive.currency}");
                }
                else
                {
                    Console.WriteLine("No active with such number. Try again");
                }
                Console.ReadLine();
            } while (answer != "exit");
        }
        protected virtual void FillThePack(PlayerEntity customer, T active)
        {
            var a = active;
            switch (a)
            {
                case Character:
                    customer.Team.Add(a as Character);
                    break;
                case Clothes:
                    customer.Wardrobe.Add(a as Clothes);
                    break;
                case Card:
                    customer.Deck.Add(a as Card);
                    break;
            }
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

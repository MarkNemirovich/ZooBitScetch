using System;

namespace ZooBitSketch
{
    internal abstract class Shop
    {
        public readonly string Name;
        protected readonly Box[] Boxes;
        protected Shop(string name, Box[] boxes)
        {
            Name = name;
            Boxes = boxes;
        }
        public void Entry(Player customer)
        {
            Info();
            string answer;
            while (true)
            {
                Description();
                answer = Console.ReadLine();
                if (answer == null)
                    continue;
                if (answer == "exit")
                    break;
                if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= Boxes.Length)
                {
                    while (true)
                    {
                        ActionChoose();
                        answer = Console.ReadLine();
                        if (answer == null)
                            continue;
                        if (answer == "exit")
                            break;
                        Int32.TryParse(answer, out int choose);
                        switch (choose)
                        {
                            case 1:
                                TryPurchase(customer, Boxes[selection-1]);
                                break;
                            case 2:
                                Info();
                                break;
                            default:
                                Console.WriteLine("No such command\nPress any key for continue...");
                                break;
                        }
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("No such item in the shop\nPress any key for continue...");
                    Console.ReadLine();
                }
            }
        }
        public virtual bool TryPurchase(Player customer, Box box)
        {
            Active[] actives;
            (int price, Currency currency) cost = box.Cost();
            switch (cost.currency)
            {
                case Currency.Money:
                    if (customer.Wallet.Money < cost.price)
                    {
                        Console.WriteLine($"You have not enough {cost.currency.ToString().ToLower()} for this");
                        return false;
                    }
                    else
                    {
                        actives = box.Open();
                        customer.Wallet.Pay(cost);
                        FillTheSlots(customer, actives);
                        return true;
                    }
                case Currency.Diamonds:
                    if (customer.Wallet.Diamonds < cost.price)
                    {
                        Console.WriteLine($"You have not enough {cost.currency.ToString().ToLower()} for this");
                        return false;
                    }
                    else
                    {
                        actives = box.Open();
                        customer.Wallet.Pay(cost);
                        FillTheSlots(customer, actives);
                        return true;
                    }
            }
            Console.WriteLine("Unexpected error");
            return false;
        }
        private void FillTheSlots(Player customer, Active[] newActives)
        {
            foreach (Active active in newActives)
            {
                if (active is Card)
                {
                    customer.Deck.Add((Card)active);
                    continue;
                }
                if (active is Character)
                {
                    customer.Team.Add((Character)active);
                    continue;
                }
                if (active is Clothes)
                {
                    customer.Wardrobe.Add((Clothes)active);
                    continue;
                }
            }
        }
        protected virtual void Description()
        {
            Console.WriteLine($"We have {Boxes.Length} boxes:\nWhat box do you interested in?\nFor exit write \"exit.\"");
            for (int i = 1; i <= Boxes.Length; i++)
                Console.WriteLine($"{i} - {Boxes[i - 1].Cost().Item2} {Boxes[i - 1].Name.ToLower()} ");
        }
        private void ActionChoose()
        {
            Console.Clear();
            Console.WriteLine($"What do you want?\n1 - Purchase\n2 - Examine\nIf you want go back, write \"exit.\"");
        }
        private void Info()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {this.GetType()} shop.");
        }
    }
}

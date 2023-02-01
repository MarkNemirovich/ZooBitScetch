using System;
using ZooBitSketch.Acquisition.Boxes;
using ZooBitSketch.Enums;
using ZooBitSketch.Property.Actives;
using ZooBitSketch.Property.PlayerThings;

namespace ZooBitSketch.Acquisition.Banners
{
    internal abstract class Banner
    {
        public readonly string Name;
        protected readonly Box[] Boxes;
        protected Banner(Box[] boxes)
        {
            Name = this.GetType().Name;
            Boxes = boxes;
        }
        public void Entry(PlayerEntity customer)
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
                                Console.WriteLine(Boxes[selection - 1].Info(customer.GetLvl));
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
        public virtual bool TryPurchase(ICustomer customer, Box box)
        {
            (int price, Currency currency) cost = box.Cost();
            if (box.TryOpen(customer, out Active[] actives))
            {
                Console.WriteLine($"You get:\n");
                FillTheSlots(customer, actives);
                return true;
            }
            else
            {
                Console.WriteLine($"You have not enough {cost.currency.ToString().ToLower()} for this");
                return false;
            }
        }
        private void FillTheSlots(ICustomer customer, Active[] newActives)
        {
            foreach (Active active in newActives)
            {
                customer.AddActive(active);
            }
        }
        private void Description()
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
            Console.WriteLine($"Welcome to the {Name} shop.");
        }
    }
}

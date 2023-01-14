using System;

namespace ZooBitSketch
{
    internal class CharactersShop
    {
        public CharacterBox SmallMoneyBox { get; private set; }
        public CharacterBox MiddleMoneyBox { get; private set; }
        public CharacterBox LargeMoneyBox { get; private set; }
        public CharactersShop()
        {
            SmallMoneyBox = new CharacterBox("Small box", 10, BoxSize.Small);
            MiddleMoneyBox = new CharacterBox("Middle box", 10, BoxSize.Middle);
            LargeMoneyBox = new CharacterBox("Large box", 10, BoxSize.Large);
        }
        public void Info()
        {
            Console.Clear();
            Console.WriteLine($"We have 3 boxes: {BoxSize.Small.ToString()}, {BoxSize.Middle.ToString()} and {BoxSize.Large.ToString()}.\n" +
                $"What box do you interested in?");
            string answer = Console.ReadLine();
            if (answer.Contains("Small"))
                Console.WriteLine(MiddleMoneyBox.Info());
            if (answer.Contains("Middle"))
                Console.WriteLine(SmallMoneyBox.Info());
            if (answer.Contains("Large"))
                Console.WriteLine(LargeMoneyBox.Info());
        }
    }
}

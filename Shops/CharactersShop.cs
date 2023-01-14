using System;

namespace ZooBitSketch
{
    internal class CharactersShop
    {
        private CharacterBox[] _boxes;
        public CharactersShop()
        {
            _boxes = new CharacterBox[6];
            _boxes[0] = new CharacterBox("Small box", 100, Currency.Money, BoxSize.Small);
            _boxes[1] = new CharacterBox("Middle box", 250, Currency.Money, BoxSize.Middle);
            _boxes[2] = new CharacterBox("Large box", 450, Currency.Money, BoxSize.Large);
            _boxes[3] = new CharacterBox("Small box", 10, Currency.Diamonds, BoxSize.Small);
            _boxes[4] = new CharacterBox("Middle box", 20, Currency.Diamonds, BoxSize.Middle);
            _boxes[5] = new CharacterBox("Large box", 45, Currency.Diamonds, BoxSize.Large);
        }
        public void Info()
        {
            Console.Clear();
            Console.WriteLine($"We have 6 boxes:\n");
            Console.WriteLine("What box do you interested in?");
            for(int i = 1; i <= _boxes.Length; i++)
                Console.WriteLine($"{i} - {_boxes[i-1].Name()}");
            string answer = Console.ReadLine();
            if (Int32.TryParse(answer, out int selection) && selection > 0 && selection <= _boxes.Length)
                Console.WriteLine(_boxes[selection-1].Info());
        }
    }
}

namespace ZooBitSketch
{
    internal class CharacterBox
    {
        private string _name;
        private int _cost;
        private Currency _currency;
        private BoxSize _size;
        public CharacterBox(string name, int cost, Currency currency, BoxSize size)
        {
            _name = name;
            _cost = cost;
            _currency = currency;
            _size = size;
        }
        public string Name() => $"{_name} for {_currency.ToString().ToLower()}";
        public string Info()
        {
            return $"\nName = {_name}\nCost = {_cost} money\nCard will be provided = {(int)_size}\n";
        }
    }
}

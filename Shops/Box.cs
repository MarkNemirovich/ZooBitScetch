using System;
using System.Text;

namespace ZooBitSketch
{
    internal abstract class Box
    {
        private string _name;
        private int _cost;
        private Currency _currency;
        private BoxSize _size;
        public Box(string name, int cost, Currency currency, BoxSize size)
        {
            _name = name;
            _cost = cost;
            _currency = currency;
            _size = size;
        }
        public string Name() => _name;
        public (int, Currency) Cost() => (_cost, _currency);
        public string Info(int playerLvl)
        {
            return $"\nName = {_name}\nCost = {_cost} money\nCards inside = {(int)_size}\n{ChancesDescription(playerLvl)}\n";
        }
        public string ChancesDescription(int playerLvl)
        {
            float common = 100 - playerLvl * ((int)_currency + 1) - 10 * (int)_currency;
            float rare = common/2 + playerLvl * ((int)_currency + 1) - 20 * (int)_currency;
            float elite = playerLvl * ((int)_currency + 1) + 20 * (int)_currency;
            float epic = elite/(100-playerLvl) + 10 * (int)_currency;
            float legendary = epic*((int)_currency + 1)*2/10;
            float total = common + rare + elite + epic + legendary;
            StringBuilder sb = new StringBuilder();
            sb.Append($"Common = {100.0* common / total:f2}%\n");
            sb.Append($"Rare = {100.0 * rare / total:f2}%\n");
            sb.Append($"Elite = {100.0 * elite / total:f2}%\n");
            sb.Append($"Epic = {100.0 * epic / total:f2}%\n");
            sb.Append($"Legendary = {100.0 * legendary / total:f2}%\n");
            return sb.ToString();
        }
    }
}

namespace ZooBitSketch
{
    internal class CharacterBox
    {
        public readonly string Name;
        public readonly int Cost;
        public readonly BoxSize Size;
        public CharacterBox(string name, int cost, BoxSize size)
        {
            Name = name;
            Cost = cost;
            Size = size;
        }
        public string Info()
        {
            return $"\nName = {Name}\nCost = {Cost} money\nCard will be provided = {(int)Size}\n";
        }
    }
}

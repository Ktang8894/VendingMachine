namespace VendingMachine
{
    public class Item
    {
        public string Name { get; set; }
        public string Flavor { get; set; }
        public string WrapperColor { get; set; }

        public Item(string name, string flavor, string wrapperColor)
        {
            Name = name;
            Flavor = flavor;
            WrapperColor = wrapperColor;
        }
    }
}

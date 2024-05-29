namespace GildedRose.Console.Entities
{
    public abstract class ItemWrapper
    {
        public string Name { get; private set; }

        public int SellInDays { get; protected set; }

        public int CurrentQuality { get; protected set; }

        protected ItemWrapper(string name, int initialSellInDays, int intialCurrentQuality)
        {
            Name = name;
            SellInDays = initialSellInDays;
            CurrentQuality = intialCurrentQuality;
        }

        public Item ToItem()
        {
            return new Item
            {
                Name = Name,
                SellIn = SellInDays,
                Quality = CurrentQuality,
            };
        }

        public abstract void UpdateCurrentQuality();
    }
}

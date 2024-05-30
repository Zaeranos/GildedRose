namespace GildedRose.Console.Entities
{
    public abstract class ItemWrapper
    {
        private readonly Item _innerItem;

        public string Name => _innerItem.Name;

        public int SellInDays 
        {
            get => _innerItem.SellIn; 
            protected set
            {
                _innerItem.SellIn = value;
            }
        }

        public int CurrentQuality 
        {
            get => _innerItem.Quality;
            protected set
            {
                _innerItem.Quality = value;
            }
        }

        protected ItemWrapper(string name, int initialSellInDays, int initialCurrentQuality)
        {
            _innerItem = new Item
            {
                Name = name,
                SellIn = initialSellInDays,
                Quality = initialCurrentQuality,
            };
        }

        public Item ToItem()
        {
            return _innerItem;
        }

        public abstract void UpdateCurrentQuality();
    }
}

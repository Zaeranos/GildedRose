namespace GildedRose.Console.Entities
{
    // In the text it is mention as "a legendary item", however there is only one.
    public class LegendaryItem : ItemWrapper
    {
        public LegendaryItem(int initialSellInDays, int intialCurrentQuality)
            : base("Sulfuras, Hand of Ragnaros", initialSellInDays, intialCurrentQuality)
        {
        }

        public override void UpdateCurrentQuality()
        {
            // Body explicitely left empty, because nothing should ever change. 
        }
    }
}

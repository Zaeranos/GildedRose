namespace GildedRose.Console.Entities
{
    // In the text it is mention as "a legendary item", however there is only one.
    public class LegendaryItem : ItemWrapper
    {
        public LegendaryItem()
            : base(
                  name: "Sulfuras, Hand of Ragnaros", 
                  initialSellInDays: 0,
                  initialCurrentQuality: 80)
        {
        }

        public override void UpdateCurrentQuality()
        {
            // Body explicitely left empty, because nothing should ever change. 
        }
    }
}

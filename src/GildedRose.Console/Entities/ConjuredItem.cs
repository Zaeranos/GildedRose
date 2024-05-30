namespace GildedRose.Console.Entities
{
    public class ConjuredItem : RegularDecreasingQualityItem
    {
        public ConjuredItem(string name, int initialSellInDays, int intialCurrentQuality)
            : base(name, initialSellInDays, intialCurrentQuality,
                  standardQualityDecreaseAmount: 2,
                  passedByDateQualityDecreaseAmount: 4)
        {
        }
    }

}

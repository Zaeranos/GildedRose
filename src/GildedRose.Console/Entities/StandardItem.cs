namespace GildedRose.Console.Entities
{

    public class StandardItem : RegularDecreasingQualityItem
    {
        public StandardItem(string name, int initialSellInDays, int intialCurrentQuality)
            : base(name, initialSellInDays, intialCurrentQuality, 
                  standardQualityDecreaseAmount: 1,
                  doubleQualityDecreaseAmount: 2)
        {
        }
    }

}

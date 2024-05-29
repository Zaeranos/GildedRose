namespace GildedRose.Console.Entities
{
    public class AgedBrieItem : ItemWrapper
    {
        private const int StandardQualityIncreaseAmount = 1;
        private const int DoubleQualityIncreaseAmount = 2;
        private const int MaximumQualityLimit = 50;

        private const int LowerByADayAmount = 1;
        private const int MinimumSellInDay = 0;

        public AgedBrieItem(int initialSellInDays, int intialCurrentQuality) 
            : base("Aged Brie", initialSellInDays, intialCurrentQuality)
        {
        }

        public override void UpdateCurrentQuality()
        {
            if (CurrentQuality < MaximumQualityLimit)
            {
                CurrentQuality += SellInDays > MinimumSellInDay
                    ? StandardQualityIncreaseAmount
                    : DoubleQualityIncreaseAmount;
            }

            SellInDays -= LowerByADayAmount;
        }
    }
}

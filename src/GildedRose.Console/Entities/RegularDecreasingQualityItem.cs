namespace GildedRose.Console.Entities
{
    public class RegularDecreasingQualityItem : ItemWrapper
    {
        private const int MinimumQuality = 0;
        private const int LowerByADayAmount = 1;
        private const int MinimumSellInDay = 0;

        private readonly int _standardQualityDecreaseAmount;
        private readonly int _doubleQualityDecreaseAmount;
        
        public RegularDecreasingQualityItem(
            string name,
            int initialSellInDays,
            int intialCurrentQuality,
            int standardQualityDecreaseAmount,
            int doubleQualityDecreaseAmount) 
            : base(name, initialSellInDays, intialCurrentQuality)
        {
            _standardQualityDecreaseAmount = standardQualityDecreaseAmount;
            _doubleQualityDecreaseAmount = doubleQualityDecreaseAmount;
        }

        public override void UpdateCurrentQuality()
        {
            CurrentQuality -= SellInDays > MinimumSellInDay 
                ? _standardQualityDecreaseAmount
                : _doubleQualityDecreaseAmount;

            if (CurrentQuality < MinimumQuality)
            {
                CurrentQuality = MinimumQuality;
            }

            SellInDays -= LowerByADayAmount;
        }
    }

}

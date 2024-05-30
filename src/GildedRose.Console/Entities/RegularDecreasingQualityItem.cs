namespace GildedRose.Console.Entities
{
    using static GeneralApplicationConstants;

    public class RegularDecreasingQualityItem : ItemWrapper
    {
        private readonly int _standardQualityDecreaseAmount;
        private readonly int _passedByDateQualityDecreaseAmount;
        
        public RegularDecreasingQualityItem(
            string name,
            int initialSellInDays,
            int intialCurrentQuality,
            int standardQualityDecreaseAmount,
            int passedByDateQualityDecreaseAmount) 
            : base(name, initialSellInDays, intialCurrentQuality)
        {
            _standardQualityDecreaseAmount = standardQualityDecreaseAmount;
            _passedByDateQualityDecreaseAmount = passedByDateQualityDecreaseAmount;
        }

        public override void UpdateCurrentQuality()
        {
            CurrentQuality -= SellInDays > Minimum_SellIn_Day_Limit
                ? _standardQualityDecreaseAmount
                : _passedByDateQualityDecreaseAmount;

            if (CurrentQuality < Minimum_Quality_Value)
            {
                CurrentQuality = Minimum_Quality_Value;
            }

            SellInDays -= Decrease_SellInDays_Amount;
        }
    }

}

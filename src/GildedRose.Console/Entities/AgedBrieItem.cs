namespace GildedRose.Console.Entities
{
    using static GeneralApplicationConstants;

    public class AgedBrieItem : ItemWrapper
    {
        private const int Standard_Quality_Increase_Amount = 1;
        private const int Passed_By_Date_Quality_Increase_Amount = 2;
        

        public AgedBrieItem(int initialSellInDays, int intialCurrentQuality) 
            : base("Aged Brie", initialSellInDays, intialCurrentQuality)
        {
        }

        public override void UpdateCurrentQuality()
        {
            
            CurrentQuality += SellInDays > Minimum_SellIn_Day_Limit
                ? Standard_Quality_Increase_Amount
                : Passed_By_Date_Quality_Increase_Amount;

            if (CurrentQuality > Maximum_Quality_Value)
            {
                CurrentQuality = Maximum_Quality_Value;
            }

            SellInDays -= Decrease_SellInDays_Amount;
        }
    }
}

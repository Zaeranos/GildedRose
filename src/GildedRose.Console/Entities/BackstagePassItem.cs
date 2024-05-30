namespace GildedRose.Console.Entities
{
    using static GeneralApplicationConstants;

    public class BackstagePassItem : ItemWrapper
    {
        private const int Standard_Quality_Increase_Amount = 1;
        private const int Near_Concert_Quality_Increase_Amount = 2;
        private const int Last_Minute_Concert_Quality_Increase_Amount = 3;
        private const int Passed_Concert_Quality_Value = 0;
        
        private const int Near_Concert_Days_Limit = 11;
        private const int Last_Minute_Concert_Days_Limit = 6;
        private const int Concert_Passed_By_Day_Limit = 0;

        public BackstagePassItem(string name, int initialSellInDays, int intialCurrentQuality) 
            : base(name, initialSellInDays, intialCurrentQuality)
        {
        }

        public override void UpdateCurrentQuality()
        {
            if (SellInDays < Concert_Passed_By_Day_Limit)
            {
                CurrentQuality = Passed_Concert_Quality_Value;
            }
            else if (SellInDays < Last_Minute_Concert_Days_Limit)
            {
                CurrentQuality += Last_Minute_Concert_Quality_Increase_Amount;
            }
            else if (SellInDays < Near_Concert_Days_Limit)
            {
                CurrentQuality += Near_Concert_Quality_Increase_Amount;
            }
            else
            { 
                CurrentQuality += Standard_Quality_Increase_Amount;
            }

            if (CurrentQuality > Maximum_Quality_Value)
            {
                CurrentQuality = Maximum_Quality_Value;
            }

            SellInDays -= Decrease_SellInDays_Amount;
        }
    }
}

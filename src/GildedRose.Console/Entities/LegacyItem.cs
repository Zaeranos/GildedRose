namespace GildedRose.Console.Entities
{
    using static GeneralApplicationConstants;

    public class LegacyItem : ItemWrapper
    {
        private const int Near_Concert_SellIn_Days_Limit = 11;
        private const int Last_Minute_Concert_SellIn_Days_Limit = 6;

        private const int Quality_Decrease_By_Amount = 1;
        private const int Quality_Increase_By_Amount = 1;

        
        public LegacyItem(string name, int initialSellInDaysDays, int intialCurrentQuality) 
            : base(name, initialSellInDaysDays, intialCurrentQuality)
        {
        }

        // Kept the original code for legacy purposes. Once a refactoring is done, this 
        // Legacy item should be removed
        public override void UpdateCurrentQuality()
        {
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (CurrentQuality > Minimum_Quality_Value)
                {
                    if (Name != "Sulfuras, Hand of Ragnaros")
                    {
                        CurrentQuality = CurrentQuality - Quality_Decrease_By_Amount;
                    }
                }
            }
            else
            {
                if (CurrentQuality < Maximum_Quality_Value)
                {
                    CurrentQuality = CurrentQuality + Quality_Increase_By_Amount;

                    if (Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (SellInDays < Near_Concert_SellIn_Days_Limit)
                        {
                            if (CurrentQuality < Maximum_Quality_Value)
                            {
                                CurrentQuality = CurrentQuality + Quality_Increase_By_Amount;
                            }
                        }

                        if (SellInDays < Last_Minute_Concert_SellIn_Days_Limit)
                        {
                            if (CurrentQuality < Maximum_Quality_Value)
                            {
                                CurrentQuality = CurrentQuality + Quality_Increase_By_Amount;
                            }
                        }
                    }
                }
            }

            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellInDays = SellInDays - Decrease_SellInDays_Amount;
            }

            if (SellInDays < Minimum_SellIn_Day_Limit)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (CurrentQuality > Minimum_Quality_Value)
                        {
                            if (Name != "Sulfuras, Hand of Ragnaros")
                            {
                                CurrentQuality = CurrentQuality - Quality_Decrease_By_Amount;
                            }
                        }
                    }
                    else
                    {
                        CurrentQuality = 0;
                    }
                }
                else
                {
                    if (CurrentQuality < Maximum_Quality_Value)
                    {
                        CurrentQuality = CurrentQuality + Quality_Increase_By_Amount;
                    }
                }
            }
        }
    }
}

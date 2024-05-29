namespace GildedRose.Console.Entities
{
    public class BackstagePassItem : ItemWrapper
    {
        private const int StandardQualityIncreaseAmount = 1;
        private const int NearConcertQualityIncreaseAmount = 2;
        private const int LastMinuteConcertQualityIncreaseAmount = 3;
        private const int MaximumQualityLimit = 50;
        private const int PassedConcertQuality = 0;

        private const int LowerByADayAmount = 1;
        private const int NearConcertDaysLimit = 11;
        private const int LastMinuteConcertDaysLimit = 6;
        private const int ConcertSellInDayLimit = 0;

        public BackstagePassItem(string name, int initialSellInDays, int intialCurrentQuality) 
            : base(name, initialSellInDays, intialCurrentQuality)
        {
        }

        public override void UpdateCurrentQuality()
        {
            if (SellInDays < ConcertSellInDayLimit)
            {
                CurrentQuality = PassedConcertQuality;
            }
            else if (SellInDays < LastMinuteConcertDaysLimit)
            {
                CurrentQuality += LastMinuteConcertQualityIncreaseAmount;
            }
            else if (SellInDays < NearConcertDaysLimit)
            {
                CurrentQuality += NearConcertQualityIncreaseAmount;
            }
            else
            { 
                CurrentQuality += StandardQualityIncreaseAmount;
            }

            if (CurrentQuality > MaximumQualityLimit)
            {
                CurrentQuality = MaximumQualityLimit;
            }

            SellInDays -= LowerByADayAmount;
        }
    }
}

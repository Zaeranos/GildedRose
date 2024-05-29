namespace GildedRose.Console.Entities
{
    public class LegacyItem : ItemWrapper
    {
        public LegacyItem(string name, int initialSellInDaysDays, int intialCurrentQuality) 
            : base(name, initialSellInDaysDays, intialCurrentQuality)
        {
        }

        public override void UpdateCurrentQuality()
        {
            if (Name != "Aged Brie" && Name != "Backstage passes to a TAFKAL80ETC concert")
            {
                if (CurrentQuality > 0)
                {
                    if (Name != "Sulfuras, Hand of Ragnaros")
                    {
                        CurrentQuality = CurrentQuality - 1;
                    }
                }
            }
            else
            {
                if (CurrentQuality < 50)
                {
                    CurrentQuality = CurrentQuality + 1;

                    if (Name == "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (SellInDays < 11)
                        {
                            if (CurrentQuality < 50)
                            {
                                CurrentQuality = CurrentQuality + 1;
                            }
                        }

                        if (SellInDays < 6)
                        {
                            if (CurrentQuality < 50)
                            {
                                CurrentQuality = CurrentQuality + 1;
                            }
                        }
                    }
                }
            }

            if (Name != "Sulfuras, Hand of Ragnaros")
            {
                SellInDays = SellInDays - 1;
            }

            if (SellInDays < 0)
            {
                if (Name != "Aged Brie")
                {
                    if (Name != "Backstage passes to a TAFKAL80ETC concert")
                    {
                        if (CurrentQuality > 0)
                        {
                            if (Name != "Sulfuras, Hand of Ragnaros")
                            {
                                CurrentQuality = CurrentQuality - 1;
                            }
                        }
                    }
                    else
                    {
                        CurrentQuality = CurrentQuality - CurrentQuality;
                    }
                }
                else
                {
                    if (CurrentQuality < 50)
                    {
                        CurrentQuality = CurrentQuality + 1;
                    }
                }
            }
        }
    }
}

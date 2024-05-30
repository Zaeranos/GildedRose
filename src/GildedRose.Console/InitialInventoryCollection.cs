using System.Collections.Generic;
using GildedRose.Console.Entities;

namespace GildedRose.Console
{
    public static class InitialInventoryCollection
    {
        public static IList<ItemWrapper> GetInitialItems()
        {
            return new List<ItemWrapper>
                    {
                        new StandardItem("+5 Dexterity Vest", 10, 20),
                        new AgedBrieItem(2, 0),
                        new StandardItem("Elixir of the Mongoose", 5, 7),
                        new LegendaryItem(),
                        new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                        new ConjuredItem("Conjured Mana Cake", 3, 6)
                    };
        }
    }

}

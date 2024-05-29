using System.Collections.Generic;
using GildedRose.Console.Application;
using GildedRose.Console.Entities;

namespace GildedRose.Console
{
    public class Program
    {
        static IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var inventory = new InventoryHandler(GetInitialItems());

            Items = inventory.GetItems();

            inventory.UpdateQuality();

            System.Console.ReadKey();

        }

        public static IList<ItemWrapper> GetInitialItems()
        {
            return new List<ItemWrapper>
                    {
                        new StandardItem("+5 Dexterity Vest", 10, 20),
                        new AgedBrieItem(2, 0),
                        new StandardItem("Elixir of the Mongoose", 5, 7),
                        new LegendaryItem(0, 80),
                        new BackstagePassItem("Backstage passes to a TAFKAL80ETC concert", 15, 20),
                        new ConjuredItem("Conjured Mana Cake", 3, 6)
                    };
        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

using System.Collections.Generic;
using GildedRose.Console.Application;

namespace GildedRose.Console
{
    class Program
    {
        static IList<Item> Items;

        static void Main(string[] args)
        {
            System.Console.WriteLine("OMGHAI!");

            var inventory = new InventoryCollection();

            Items = inventory.GetItems();

            inventory.UpdateQuality();

            System.Console.ReadKey();

        }

    }

    public class Item
    {
        public string Name { get; set; }

        public int SellIn { get; set; }

        public int Quality { get; set; }
    }

}

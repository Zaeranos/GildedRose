using System.Collections.Generic;

namespace GildedRose.Console.Application
{
    public interface IInventory
    {
        Item GetItemByName(string name);
        IList<Item> GetItems();
        void UpdateQuality();

        string PrintInventory();
    }
}

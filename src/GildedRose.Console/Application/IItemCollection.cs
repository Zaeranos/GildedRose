using System.Collections.Generic;

namespace GildedRose.Console.Application
{
    public interface IItemCollection
    {
        Item GetItemByName(string name);
        IList<Item> GetItems();
    }
}

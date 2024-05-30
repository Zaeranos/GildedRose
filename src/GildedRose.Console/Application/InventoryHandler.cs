using System.Collections.Generic;
using System.Linq;
using System.Text;
using GildedRose.Console.Entities;

namespace GildedRose.Console.Application
{

    public class InventoryHandler : IInventory, IItemCollection
    {
        private readonly IList<ItemWrapper> _items;

        public InventoryHandler(IList<ItemWrapper> items)
        {
            _items = items;
        }

        public Item GetItemByName(string name)
        {
            return _items.SingleOrDefault(item => item.Name == name)?.ToItem();
        }

        public IList<Item> GetItems() => _items.Select(item => item.ToItem()).ToList();

        public void UpdateQuality()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                _items[i].UpdateCurrentQuality();
            }
        }

        public string PrintInventory()
        {
            var sb = new StringBuilder("Inventory:");
            sb.AppendLine();

            for (var i = 0; i < _items.Count; i++)
            {
                sb.AppendLine($"- {_items[i].Name}: Sell in days = {_items[i].SellInDays}, current quality = {_items[i].CurrentQuality}.");
            }

            return sb.ToString();
        }
    }
}

namespace GildedRose.Console.Application
{
    public interface IInventory
    {
        Item GetItemByName(string name);
        void UpdateQuality();
    }
}

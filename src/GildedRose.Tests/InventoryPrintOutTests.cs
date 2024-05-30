using GildedRose.Console.Application;
using GildedRose.Console;
using Xunit;

namespace GildedRose.Tests
{
    public class InventoryPrintOutTests
    {
        private const string initialStatePrint = "Inventory:\r\n- +5 Dexterity Vest: Sell in days = 10, current quality = 20.\r\n- Aged Brie: Sell in days = 2, current quality = 0.\r\n- Elixir of the Mongoose: Sell in days = 5, current quality = 7.\r\n- Sulfuras, Hand of Ragnaros: Sell in days = 0, current quality = 80.\r\n- Backstage passes to a TAFKAL80ETC concert: Sell in days = 15, current quality = 20.\r\n- Conjured Mana Cake: Sell in days = 3, current quality = 6.\r\n";

        private const string after1DayPrint = "Inventory:\r\n- +5 Dexterity Vest: Sell in days = 9, current quality = 19.\r\n- Aged Brie: Sell in days = 1, current quality = 1.\r\n- Elixir of the Mongoose: Sell in days = 4, current quality = 6.\r\n- Sulfuras, Hand of Ragnaros: Sell in days = 0, current quality = 80.\r\n- Backstage passes to a TAFKAL80ETC concert: Sell in days = 14, current quality = 21.\r\n- Conjured Mana Cake: Sell in days = 2, current quality = 4.\r\n";

        private const string after20DayPrint = "Inventory:\r\n- +5 Dexterity Vest: Sell in days = -10, current quality = 0.\r\n- Aged Brie: Sell in days = -18, current quality = 38.\r\n- Elixir of the Mongoose: Sell in days = -15, current quality = 0.\r\n- Sulfuras, Hand of Ragnaros: Sell in days = 0, current quality = 80.\r\n- Backstage passes to a TAFKAL80ETC concert: Sell in days = -5, current quality = 0.\r\n- Conjured Mana Cake: Sell in days = -17, current quality = 0.\r\n";

        [Fact]
        public void Print_Out_Initial_Inventory_State()
        {
            // Arrange
            var inventory = new InventoryHandler(Program.GetInitialItems());

            // Act
            var actual = inventory.PrintInventory();

            // Assert
            Assert.Equal(initialStatePrint, actual);
        }

        [Fact]
        public void Print_Out_Inventory_State_After_One_Day()
        {
            // Arrange
            var inventory = new InventoryHandler(Program.GetInitialItems());
            inventory.UpdateQuality();

            // Act
            var actual = inventory.PrintInventory();

            // Assert
            Assert.Equal(after1DayPrint, actual);
        }

        [Fact]
        public void Print_Out_Inventory_State_After_20_Days()
        {
            // Arrange
            var inventory = new InventoryHandler(Program.GetInitialItems());
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();
            inventory.UpdateQuality();

            // Act
            var actual = inventory.PrintInventory();

            // Assert
            Assert.Equal(after20DayPrint, actual);
        }
    }

}
using GildedRose.Console;
using GildedRose.Console.Application;
using Xunit;

namespace GildedRose.Tests
{
    public class InitiallyRequestItems
    {
        [Theory(DisplayName = "Given the inventory is just initialized, when requesting an item, then the item with the matching SellIn value is returned")]
        [InlineData("+5 Dexterity Vest", 10)]
        [InlineData("Aged Brie", 2)]
        [InlineData("Elixir of the Mongoose", 5)]
        [InlineData("Sulfuras, Hand of Ragnaros", 0)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 15)]
        [InlineData("Conjured Mana Cake", 3)]
        public void Getting_The_Items_To_Check_Initial_Sellin_Values(string name, int expectedSellIn)
        {
            // Arrange
            var inventory = new InventoryHandler(InitialInventoryCollection.GetInitialItems());

            // Act
            var actual = inventory.GetItemByName(name);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedSellIn, actual.SellIn);
        }

        [Theory(DisplayName = "Given the inventory is just initialized, when requesting an item, then the item with the matching Quality value is returned")]
        [InlineData("+5 Dexterity Vest", 20)]
        [InlineData("Aged Brie", 0)]
        [InlineData("Elixir of the Mongoose", 7)]
        [InlineData("Sulfuras, Hand of Ragnaros", 80)]
        [InlineData("Backstage passes to a TAFKAL80ETC concert", 20)]
        [InlineData("Conjured Mana Cake", 6)]
        public void Getting_The_Items_To_Check_Initial_Quality_Values(string name, int expectedQuality)
        {
            // Arrange
            var inventory = new InventoryHandler(InitialInventoryCollection.GetInitialItems());

            // Act
            var actual = inventory.GetItemByName(name);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedQuality, actual.Quality);
        }
    }

}
using System.Collections.Generic;
using GildedRose.Console.Application;
using GildedRose.Console.Entities;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdatingLegendaryItemQuality
    {
        private const string LegendaryItemName = "Sulfuras, Hand of Ragnaros";

        [Fact]
        public void UpdatingItemQuality_For_Legendary_Items_Should_Never_Lower_The_Quality()
        {
            // Arrange
            var expectedQuality = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new LegendaryItem(10, expectedQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(LegendaryItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Legendary_Items_Should_Never_Lower_The_SellInDays()
        {
            // Arrange
            var expectedSellInDays = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new LegendaryItem(expectedSellInDays, 10)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(LegendaryItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedSellInDays, actual.SellIn);
        }
    }
}
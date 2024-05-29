using System.Collections.Generic;
using GildedRose.Console.Application;
using GildedRose.Console.Entities;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdatingStandardItemQuality
    {
        private const string StandardItemName = "Standard item";

        [Fact]
        public void UpdatingItemQuality_For_Standard_Items_Not_Passed_SellInDays_Should_Lower_The_Quality_By_One()
        {
            // Arrange
            var initialQuality = 11;
            var expectedNewQuality = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new StandardItem(StandardItemName, 10, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(StandardItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Standard_Items_Passed_SellInDays_Should_Lower_The_Quality_Twice_As_Fast()
        {
            // Arrange
            var initialQuality = 11;
            var expectedNewQuality = 9;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new StandardItem(StandardItemName, 0, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(StandardItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Standard_Items_Should_Never_Lower_The_Quality_In_The_Negative()
        {
            // Arrange
            var initialQuality = -1;
            var expectedNewQuality = 0;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new StandardItem(StandardItemName, 0, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(StandardItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Standard_Items_Should_Lower_The_SellInDays_By_One()
        {
            // Arrange
            var initialSellInDays = 11;
            var expectedNewSellInDays = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new StandardItem(StandardItemName, initialSellInDays, 10)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(StandardItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewSellInDays, actual.SellIn);
        }
    }

    public class UpdatingConjuredItemQuality
    {
        private const string ConjuredItemName = "Conjured item";

        [Fact]
        public void UpdatingItemQuality_For_Conjured_Items_Not_Passed_SellInDays_Should_Lower_The_Quality_By_Two()
        {
            // Arrange
            var initialQuality = 10;
            var expectedNewQuality = 8;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new ConjuredItem(ConjuredItemName, 10, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(ConjuredItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Conjured_Items_Passed_SellInDays_Should_Lower_The_Quality_Twice_As_Fast()
        {
            // Arrange
            var initialQuality = 10;
            var expectedNewQuality = 6;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new ConjuredItem(ConjuredItemName, 0, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(ConjuredItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Conjured_Items_Should_Never_Lower_The_Quality_In_The_Negative()
        {
            // Arrange
            var initialQuality = -1;
            var expectedNewQuality = 0;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new ConjuredItem(ConjuredItemName, 0, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(ConjuredItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Conjured_Items_Should_Lower_The_SellInDays_By_One()
        {
            // Arrange
            var initialSellInDays = 11;
            var expectedNewSellInDays = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new ConjuredItem(ConjuredItemName, initialSellInDays, 10)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(ConjuredItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewSellInDays, actual.SellIn);
        }
    }
}
using System.Collections.Generic;
using GildedRose.Console.Application;
using GildedRose.Console.Entities;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdatingAgedBrieItemQuality
    {
        private const string AgedBrieName = "Aged Brie";

        [Fact]
        public void UpdatingItemQuality_For_Aged_Brie_Not_At_Max_Quality_Should_Increase_The_Quality_By_One()
        {
            // Arrange
            var initialQuality = 2;
            var expectedNewQuality = 3;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new AgedBrieItem(10, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(AgedBrieName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }


        [Fact]
        public void UpdatingItemQuality_For_Aged_Brie_Passed_SellInDays_Should_Increase_The_Quality_Twice_As_Fast()
        {
            // Arrange
            var initialQuality = 9;
            var expectedNewQuality = 11;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new AgedBrieItem(0, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(AgedBrieName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Aged_Brie_At_Max_Quality_Of_50_Should_Not_Increase_The_Quality()
        {
            // Arrange
            var expectedQuality = 50;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new AgedBrieItem(10, expectedQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(AgedBrieName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedQuality, actual.Quality);
        }


        [Fact]
        public void UpdatingItemQuality_For_Aged_Brie_Should_Lower_The_SellInDays_By_One()
        {
            // Arrange
            var initialSellInDays = 11;
            var expectedNewSellInDays = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new AgedBrieItem(initialSellInDays, 10)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(AgedBrieName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewSellInDays, actual.SellIn);
        }
    }
}
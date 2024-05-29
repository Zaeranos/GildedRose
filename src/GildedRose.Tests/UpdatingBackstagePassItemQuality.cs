using System.Collections.Generic;
using GildedRose.Console.Application;
using GildedRose.Console.Entities;
using Xunit;

namespace GildedRose.Tests
{
    public class UpdatingBackstagePassItemQuality
    {
        private const string BackstagePassItemName = "Backstage pass item";

        [Theory]
        [InlineData(100)]
        [InlineData(25)]
        [InlineData(13)]
        [InlineData(12)]
        [InlineData(11)]
        public void UpdatingItemQuality_For_Backstage_Passes_Not_Passed_SellInDays_Should_Increase_Standard_The_Quality_By_One(int sellInDays)
        {
            // Arrange
            var initialQuality = 10;
            var expectedNewQuality = 11;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new BackstagePassItem(BackstagePassItemName, sellInDays, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(BackstagePassItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Theory]
        [InlineData(10)]
        [InlineData(9)]
        [InlineData(8)]
        [InlineData(7)]
        [InlineData(6)]
        public void UpdatingItemQuality_For_Backstage_Passes_10_Days_Or_Less_From_Concert_Should_Increase_The_Quality_By_Two(int sellInDays)
        {
            // Arrange
            var initialQuality = 10;
            var expectedNewQuality = 12;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new BackstagePassItem(BackstagePassItemName, sellInDays, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(BackstagePassItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Theory]
        [InlineData(5)]
        [InlineData(4)]
        [InlineData(3)]
        [InlineData(2)]
        [InlineData(1)]
        public void UpdatingItemQuality_For_Backstage_Passes_5_Days_Or_Less_From_Concert_Should_Increase_The_Quality_By_Three(int sellInDays)
        {
            // Arrange
            var initialQuality = 10;
            var expectedNewQuality = 13;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new BackstagePassItem(BackstagePassItemName, sellInDays, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(BackstagePassItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(-2)]
        [InlineData(-3)]
        [InlineData(-100)]
        public void UpdatingItemQuality_For_Backstage_Passes_After_The_Concert_Should_Have_No_Quality(int sellInDays)
        {
            // Arrange
            var initialQuality = 10;
            var expectedNewQuality = 0;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new BackstagePassItem(BackstagePassItemName, sellInDays, initialQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(BackstagePassItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Backstage_Passes_At_Max_Quality_Of_50_Should_Not_Increase_The_Quality()
        {
            // Arrange
            var expectedQuality = 50;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new BackstagePassItem(BackstagePassItemName, 10, expectedQuality)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(BackstagePassItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedQuality, actual.Quality);
        }

        [Fact]
        public void UpdatingItemQuality_For_Backstage_Passes_Should_Lower_The_SellInDays_By_One()
        {
            // Arrange
            var initialSellInDays = 11;
            var expectedNewSellInDays = 10;

            var inventory = new InventoryHandler(new List<ItemWrapper>()
            {
                new BackstagePassItem(BackstagePassItemName, initialSellInDays, 10)
            });


            // Act
            inventory.UpdateQuality();
            var actual = inventory.GetItemByName(BackstagePassItemName);

            // Assert
            Assert.NotNull(actual);
            Assert.Equal(expectedNewSellInDays, actual.SellIn);
        }
    }
}
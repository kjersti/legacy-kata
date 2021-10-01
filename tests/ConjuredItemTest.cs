using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using Xunit;

namespace tests
{
    public class ConjuredItemTest
    {
        [Fact]
        public void QualityShouldDecreaseByTwoTest()
        {
            var list = GenerateItems(3, 6);
            var gildedRose = new GildedRose(list);
            gildedRose.ConjuredEnabled = true;
            Assert.Equal(6,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(4,list.First().Quality);
        }
        
        [Fact]
        public void QualityCannotBeNegativeTest()
        {
            var list = GenerateItems(3, 3);
            var gildedRose = new GildedRose(list);
            gildedRose.ConjuredEnabled = true;
            Assert.Equal(3,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(1,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(0,list.First().Quality);
        }
        
        [Fact]
        public void QualityAfterSellDateTest()
        {
            var list = GenerateItems(1, 10);
            var gildedRose = new GildedRose(list);
            gildedRose.ConjuredEnabled = true;
            Assert.Equal(10,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(8,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(6,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(2,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(0,list.First().Quality);
        }

        private IList<Item> GenerateItems(int sellIn, int quality)
        {
             IList<Item> items = new List<Item>{
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = sellIn, Quality = quality}
            };

             return items;
        }
    }
}
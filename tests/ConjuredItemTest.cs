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
            var list = GenerateItems(6);
            var gildedRose = new GildedRose(list);
            gildedRose.ConjuredEnabled = true;
            Assert.Equal(6,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(4,list.First().Quality);
        }
        
        [Fact]
        public void QualityCannotBeNegativeTest()
        {
            var list = GenerateItems(3);
            var gildedRose = new GildedRose(list);
            gildedRose.ConjuredEnabled = true;
            Assert.Equal(3,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(1,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(0,list.First().Quality);
        }

        private IList<Item> GenerateItems(int quality)
        {
             IList<Item> items = new List<Item>{
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = quality}
            };

             return items;
        }
    }
}
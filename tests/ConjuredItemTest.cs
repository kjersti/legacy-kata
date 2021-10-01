using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using Xunit;

namespace tests
{
    public class ConjuredItemTest
    {
        [Fact]
        public void Test1()
        {
            var list = GenerateItems();
            var gildedRose = new GildedRose(list);
            Assert.Equal(6,list.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(4,list.First().Quality);
        }

        private IList<Item> GenerateItems()
        {
             IList<Item> items = new List<Item>{
				// this conjured item does not work properly yet
				new Item {Name = "Conjured Mana Cake", SellIn = 3, Quality = 6}
            };

             return items;
        }
    }
}
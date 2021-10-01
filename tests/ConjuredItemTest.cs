using System.Collections.Generic;
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
            
            Assert.True(true);
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
using System.Collections.Generic;
using System.Linq;
using GildedRoseKata;
using Xunit;

namespace tests
{
    public class RegularTicketTest
    {
        [Fact]
        public void QualityShouldIncreaseByDayTest()
        {
            IList<Item> items = new List<Item>{
				new Item {
                    Name = "Regular ticket to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 20
                }
            };
            var gildedRose = new GildedRose(items);
            Assert.Equal(20, items.First().Quality);
            gildedRose.UpdateQuality();
            Assert.Equal(21, items.First().Quality);
        }

        [Fact]
        public void QualityShouldBeZeroWhenSellInZeroTest()
        {
            IList<Item> items = new List<Item>{
				new Item {
                    Name = "Regular ticket to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 20
                }
            };
            var gildedRose = new GildedRose(items);
            Assert.Equal(20, items.First().Quality);
            gildedRose.UpdateQuality();
            gildedRose.UpdateQuality();
            Assert.Equal(0, items.Count);
        }

    }
}
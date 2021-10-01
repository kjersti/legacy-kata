using System.Collections.Generic;
using GildedRoseKata;
using Xunit;

namespace tests
{
    public class TicketTest
    {
        [Fact]
        public void TicketsShouldBeRemovedFromInventoryAfterConcert()
        {
            IList<Item> items = new List<Item>{
                new Item {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 20
                },
                new Item {
                    Name = "Regular ticket to a TAFKAL80ETC concert",
                    SellIn = 1,
                    Quality = 20
                }
            };
            var gildedRose = new GildedRose(items);
            Assert.Equal(2, items.Count);
            gildedRose.UpdateQuality();
            Assert.Equal(2, items.Count);
            gildedRose.UpdateQuality();
            Assert.Equal(0, items.Count);
        }
    }
}
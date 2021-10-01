using System;
using System.Collections.Generic;

namespace GildedRoseKata
{
    public class GildedRose
    {
        private readonly IList<Item> _items;
        public bool ConjuredEnabled = false;

        public GildedRose(IList<Item> items)
        {
            _items = items;
        }

        public void UpdateQuality()
        {
            var itemsToRemove = new List<Item>();

            foreach (var t in _items)
            {
                if (ConjuredEnabled && t.Name == "Conjured Mana Cake")
                {
                    t.Quality = Math.Max(0, t.Quality - (t.SellIn < 0 ? 4 : 2));
                    t.SellIn = t.SellIn - 1;
                    continue;
                }

                if (t.Name != "Aged Brie" && t.Name != "Backstage passes to a TAFKAL80ETC concert" &&
                    t.Name != "Regular ticket to a TAFKAL80ETC concert")
                {
                    if (t.Quality > 0)
                        if (t.Name != "Sulfuras, Hand of Ragnaros")
                            t.Quality = t.Quality - 1;
                }
                else
                {
                    if (t.Quality < 50)
                    {
                        t.Quality = t.Quality + 1;

                        if (t.Name == "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (t.SellIn < 11)
                                if (t.Quality < 50)
                                    t.Quality = t.Quality + 1;

                            if (t.SellIn < 6)
                                if (t.Quality < 50)
                                    t.Quality = t.Quality + 1;
                        }
                    }
                }

                if (t.Name != "Sulfuras, Hand of Ragnaros") t.SellIn = t.SellIn - 1;

                if (t.SellIn < 0)
                {
                    if (t.Name == "Regular ticket to a TAFKAL80ETC concert") t.Quality = 0;

                    if (t.Name != "Aged Brie")
                    {
                        if (t.Name != "Backstage passes to a TAFKAL80ETC concert")
                        {
                            if (t.Quality > 0)
                                if (t.Name != "Sulfuras, Hand of Ragnaros")
                                    t.Quality = t.Quality - 1;
                        }
                        else
                        {
                            t.Quality = t.Quality - t.Quality;
                        }

                        if (t.Name is "Regular ticket to a TAFKAL80ETC concert" or
                            "Backstage passes to a TAFKAL80ETC concert") itemsToRemove.Add(t);
                    }
                    else
                    {
                        if (t.Quality < 50) t.Quality = t.Quality + 1;
                    }
                }
            }

            foreach (var item in itemsToRemove) _items.Remove(item);
        }
    }
}
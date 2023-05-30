using GlidedRose.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlidedRose.BusinessLogic
{
    public class GlidedRoseLogic
    {
        private IList<Item> Items;
        public GlidedRoseLogic(IList<Item> Items)
        {
            this.Items = Items;
        }
        public void UpdateQuality()
        {
            for (var i = 0; i < Items.Count; i++)
            {
                Item item = Items[i];
                switch (item.Name)
                {
                    case GlidedRoseLogicConstants.AGED_BRIE:
                        ProcessAgedBrie(item);
                        break;
                    case GlidedRoseLogicConstants.BACKSTAGE_PASSES:
                        ProcessBackStagePass(item);
                        break;
                    case GlidedRoseLogicConstants.SULFURAS:
                        ProcessSulfuras(item);
                        break;
                    case GlidedRoseLogicConstants.CONJURED:
                        ProcessConjured(item);
                        break;
                    default:
                        ProcessRegularItem(item);
                        break;
                }
            }
        }

        private static void ProcessConjured(Item item)
        {
            if (IsConjured(item))
            {
                item.SellIn--;
                item.Quality = item.Quality - 2;
            }
        }
        private static void ProcessSulfuras(Item item)
        {
            if (IsSulfuras(item))
                item.SellIn--;
        }
        private static void ProcessBackStagePass(Item item)
        {
            if (IsBackStagePass(item))
            {
                item.SellIn--;
                item.Quality++;
                if (item.SellIn < GlidedRoseLogicConstants.BACKSTAGE_PASSES_SELLIN_LIMIT_STAGE1)
                    item.Quality++;
                if (item.SellIn < GlidedRoseLogicConstants.BACKSTAGE_PASSES_SELLIN_LIMIT_STAGE2)
                    item.Quality++;
                if (item.SellIn <= 0)
                    item.Quality = 0;
                if (item.Quality > GlidedRoseLogicConstants.MAX_QUALITY)
                    item.Quality = GlidedRoseLogicConstants.MAX_QUALITY;
            }
        }
        private static void ProcessAgedBrie(Item item)
        {
            if (IsAgedBrie(item))
            {
                item.SellIn--;
                item.Quality++;
                if (item.SellIn <= 0)
                {
                    item.Quality++;
                }
                if (IfExceedingMaxQuality(item))
                    item.Quality = GlidedRoseLogicConstants.MAX_QUALITY;
            }
        }
        private static void ProcessRegularItem(Item item)
        {
            if (IsRegularItem(item))
            {
                item.SellIn--;
                item.Quality--;
                if (item.SellIn <= 0)
                {
                    item.Quality--;
                }
                if (item.Quality < 0)
                {
                    item.Quality = 0;
                }
            }
        }
        private static bool IsRegularItem(Item item)
        {
            return !(IsAgedBrie(item) || IsSulfuras(item) || IsBackStagePass(item) || IsConjured(item));
        }
        private static bool IfExceedingMaxQuality(Item item)
        {
            return item.Quality > GlidedRoseLogicConstants.MAX_QUALITY;
        }
        private static bool IsSulfuras(Item item)
        {
            return item.Name == GlidedRoseLogicConstants.SULFURAS;
        }
        private static bool IsBackStagePass(Item item)
        {
            return item.Name == GlidedRoseLogicConstants.BACKSTAGE_PASSES;
        }
        private static bool IsAgedBrie(Item item)
        {
            return item.Name == GlidedRoseLogicConstants.AGED_BRIE;
        }
        private static bool IsConjured(Item item)
        {
            return item.Name == GlidedRoseLogicConstants.CONJURED;
        }
    }
}

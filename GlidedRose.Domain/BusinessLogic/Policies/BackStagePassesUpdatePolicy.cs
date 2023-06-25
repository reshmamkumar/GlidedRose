using GlidedRose.Domain.BusinessLogic.Constants;
using GlidedRose.Domain.BusinessLogic.Policies.Interface;
using GlidedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlidedRose.Domain.BusinessLogic.Policies
{
    public class BackStagePassesUpdatePolicy : IStockItemUpdatePolicy
    {
        public void UpdateItem(Item item)
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
}

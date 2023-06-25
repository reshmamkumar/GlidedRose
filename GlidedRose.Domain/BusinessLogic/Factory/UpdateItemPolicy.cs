using GlidedRose.Domain.BusinessLogic.Constants;
using GlidedRose.Domain.BusinessLogic.Policies;
using GlidedRose.Domain.BusinessLogic.Policies.Interface;
using GlidedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlidedRose.Domain.BusinessLogic.Factory
{
    public class UpdateItemPolicy : IUpdateItemPolicy
    {
        public IStockItemUpdatePolicy Create(Item item)
        {
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }

            switch (item.Name)
            {
                case GlidedRoseLogicConstants.AGED_BRIE:
                    return new AgedBrieUpdatePolicy();
                case GlidedRoseLogicConstants.BACKSTAGE_PASSES:
                    return new BackStagePassesUpdatePolicy();
                case GlidedRoseLogicConstants.SULFURAS:
                    return new SulurasUpdatePolicy();
                case GlidedRoseLogicConstants.CONJURED:
                    return new ConjuredUpdatePolicy();
                default:
                    return new StandardItemsUpdatePolicy();
            }
        }
    }
}

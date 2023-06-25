using GlidedRose.Domain.BusinessLogic.Policies.Interface;
using GlidedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlidedRose.Domain.BusinessLogic.Policies
{
    public class StandardItemsUpdatePolicy : IStockItemUpdatePolicy
    {
        public void UpdateItem(Item item)
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
}

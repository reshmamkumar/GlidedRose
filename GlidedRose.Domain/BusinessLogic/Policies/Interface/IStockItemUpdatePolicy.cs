using GlidedRose.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlidedRose.Domain.BusinessLogic.Policies.Interface
{
    public interface IStockItemUpdatePolicy
    {
        void UpdateItem(Item item);
    }
}

using _0_FrameWork.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository : Irepository<long,Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetBy(long ProductId);
        List<InventoryViewModel> Serach(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long InventoryId);
    }
}

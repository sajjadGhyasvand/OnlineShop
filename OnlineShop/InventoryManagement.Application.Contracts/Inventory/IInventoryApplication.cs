using _0_FrameWork.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OprationResult Create(CreateInventory command);
        OprationResult Edit(EditInventory command);
        OprationResult Increase(IncreaseInventory command);
        OprationResult Reduce(DecreaseInventory command);
        OprationResult Reduce(List<DecreaseInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long InventoryId);
    }
}

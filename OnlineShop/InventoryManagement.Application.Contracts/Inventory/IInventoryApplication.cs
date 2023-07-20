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
        OprationResult Decrease(List<DecreaseInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventoryViewModel searchModel);
    }
}

using DiscountManagement.Application.Contract.CustomerDiscount;
using InventoryManagement.Application.Contract.Inventory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Inventory
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string message { get; set; }
        public List<InventoryViewModel> Inventory;
        public InventorySearchModel SearchModel;
        public SelectList Products;

        private readonly IPorductApplication _productApplication;
        private readonly IInventoryApplication _inventoryApplication;
        public IndexModel(IPorductApplication productApplication, IInventoryApplication inventoryApplication)
        {
            _productApplication=productApplication;
            _inventoryApplication=inventoryApplication;
        }
        public void OnGet(InventorySearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            Inventory =  _inventoryApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateInventory
            {
                Products = _productApplication.GetProducts()
            };
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreateInventory command)
        {
            var result = _inventoryApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var inventory = _inventoryApplication.GetDetails(id);
            inventory.Products = _productApplication.GetProducts();
            return Partial("Edit", inventory);
        }
        public JsonResult OnPostEdit(EditInventory command)
        {
            var result = _inventoryApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetIncrease(long id)
        {
            var command = new IncreaseInventory()
            {
                InventoryId = id
            };
            return Partial("Increase", command);
        }
        public JsonResult OnPostIncrease(IncreaseInventory command)
        {
            var result = _inventoryApplication.Increase(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetDecrease(long id)
        {
            var command = new DecreaseInventory()
            {
                InventoryId = id
            };
            return Partial("Decrease", command);
        }
        public JsonResult OnPostDecrease(DecreaseInventory command)
        {
            var result = _inventoryApplication.Reduce(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetLog(long id)
        {
            var log = _inventoryApplication.GetOperationLog(id);
            return Partial("OperationLog",log);
        }
    }
}

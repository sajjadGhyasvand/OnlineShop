using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application;
using ShopManagement.Application.Contracts.PoductPicture;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administration.Pages.Shop.ProductPictures
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string message { get; set; }
        private readonly IPorductApplication _productApplication;
        private readonly IProductPictureApplication _productPictureApplication;
        public List<ProductPictureViewModel> ProductPictures;
        public ProductPictureSearchModel SearchModel;
        public SelectList Products;
        public IndexModel(IPorductApplication productApplication, IProductPictureApplication productPictureApplication)
        {
            _productApplication=productApplication;
            _productPictureApplication=productPictureApplication;
        }
        public void OnGet(ProductPictureSearchModel searchModel)
        {
            Products = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductPictures =  _productPictureApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreatePoductPicture();
            command.Products = _productApplication.GetProducts();
            return Partial("./Create", command);
        }
        public JsonResult OnPostCreate(CreatePoductPicture command)
        {
            var result = _productPictureApplication.Create(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetEdit(long id)
        {
            var product = _productPictureApplication.GetDetails(id);
            product.Products= _productApplication.GetProducts();
            return Partial("Edit", product);
        }
        public JsonResult OnPostEdit(EditPoductPicture command)
        {
            var result = _productPictureApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
           var result = _productPictureApplication.Remove(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            message = result.Message;
            return RedirectToPage("./Index");
        }
        public IActionResult OnGetIsRestore(long id)
        {
            var result = _productPictureApplication.Restore(id);
            if (result.IsSuccedded)
                return RedirectToPage("./Index");
            message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}

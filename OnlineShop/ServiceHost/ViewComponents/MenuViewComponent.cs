using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class MenuViewComponent : ViewComponent
    {
        private readonly _01_Query.Contract.ProductCategory.IProductCategoryQuery _productCategoryQuery;

        public MenuViewComponent(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery=productCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var result = _productCategoryQuery.GetProductCategories();
            return View(result);
        }
    }
}

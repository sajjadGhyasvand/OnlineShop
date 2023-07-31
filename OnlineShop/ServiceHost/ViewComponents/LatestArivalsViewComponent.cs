using _01_Query.Contract.Product;
using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace ServiceHost.ViewComponents
{
    public class LatestArivalsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public LatestArivalsViewComponent(IProductQuery productQuery)
        {
            _productQuery=productQuery;
        }
        public IViewComponentResult Invoke()
        {
           var productCategories = _productQuery.GetLatestArrivals();
           return View(productCategories);
        }
    }
}

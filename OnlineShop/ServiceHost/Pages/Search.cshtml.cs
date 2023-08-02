using _01_Query.Contract.Product;
using _01_Query.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace ServiceHost.Pages
{
    public class SearchModel : PageModel
    {
        public string value;
        private readonly IProductQuery _productQuery;
        public List<ProductQueryModel> Products;
        public SearchModel(IProductQuery productQuery)
        {
            _productQuery=productQuery;
        }

        public void OnGet(string value)
        {
            value=value;
        }
    }
}

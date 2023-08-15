using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.Product;

namespace ShopManagement.Domain.ProductAgg
{
    public interface  IProductRepository : Irepository<long, Product>
    {
        Product GetProductWithCategory(long id);
        EditProduct GetDetails(long id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);  

    }
}

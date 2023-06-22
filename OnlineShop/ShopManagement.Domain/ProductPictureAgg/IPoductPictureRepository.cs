using _0_FrameWork.Domain;
using ShopManagement.Application.Contracts.PoductPicture;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public interface IPoductPictureRepository : Irepository<long, ProductPicture>
    {
        EditPoductPicture GetDetails(long id);
        List<ProductPictureViewModel> search(ProductPictureSearchModel searchModel);
    }
}

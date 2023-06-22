using _0_FrameWork.Domain;
using System.Linq.Expressions;

namespace ShopManagement.Domain.ProductPictureAgg
{
    internal class IPoductPictureRepository : Irepository<long, ProductPicture>
    {
        public void Create(ProductPicture entity)
        {
            throw new NotImplementedException();
        }

        public bool Exists(Expression<Func<ProductPicture, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public ProductPicture Get(long id)
        {
            throw new NotImplementedException();
        }

        public List<ProductPicture> GetAll()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

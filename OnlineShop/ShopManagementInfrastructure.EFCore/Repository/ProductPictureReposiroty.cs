using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.PoductPicture;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class ProductPictureReposiroty : RepositoryBase<long, ProductPicture>, IPoductPictureRepository
    {
        private readonly ShopContext _Context;
        public ProductPictureReposiroty(ShopContext context) : base(context)
        {
            _Context=context;
        }
        public EditPoductPicture GetDetails(long id)
        {
            return _Context.ProductPictures.Select(x => new EditPoductPicture
            {
                Id = x.Id,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId,
            }).FirstOrDefault(x => x.Id == id);
        }

        public ProductPicture GetWithProductAndCategory(long id)
        {
            return _Context.ProductPictures
                .Include(x => x.Product)
                .ThenInclude(x => x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ProductPictureViewModel> search(ProductPictureSearchModel searchModel)
        {
            var query = _Context.ProductPictures.Include(x=>x.Product).Select(x => new ProductPictureViewModel 
            {
                Id= x.Id,
                Product=x.Product.Name,
                CreationDate = x.CreationDate.ToString(),
                Picture = x.Picture ,
                ProductId = x.ProductId,
                IsRemoved = x.IsRemoved,
            });
            if (searchModel.ProductId!=0)
                query = query.Where(x=>x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x=>x.Id).ToList();

        }
    }
}

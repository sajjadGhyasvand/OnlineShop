using _0_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class ProductCategoryRepository : RepositoryBase<long,ProductCategory> , IProductCategoryRepository
    {

        private readonly ShopContext _context;

        public ProductCategoryRepository(ShopContext context) : base(context)
        {
            _context=context;
        }

        public EditProductCategory GetDetails(long id)
        {
            #pragma warning disable CS8603 // Possible null reference return.
            return _context.ProductCategories.Select(x => new EditProductCategory()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                KeyWords = x.KeyWords,
                MetaDescription = x.MetaDescription,
                Picture=x.Picture,
                PictureAlt=x.PictureAlt,
                PictureTitle=x.PictureTitle,
                Slug=x.Slug,
            }).FirstOrDefault(x => x.Id == id);
            #pragma warning restore CS8603 // Possible null reference return.
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(x=>new ProductCategoryViewModel
            {
                Id = x.Id,
                Name=x.Name,
            }).ToList();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            var query = _context.ProductCategories.Select(x => new ProductCategoryViewModel()
            {
                Id = x.Id,
                Picture = x.Picture,
                Name = x.Name,
                CreationDate = x.CreationDate.ToString()
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x=>x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x=>x.Id).ToList();
        }
    }
}

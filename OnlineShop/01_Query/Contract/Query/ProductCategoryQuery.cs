using _01_Query.Contract.ProductCategory;
using ShopManagementInfrastructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Query.Contract.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _context;

        public ProductCategoryQuery(ShopContext context)
        {
            _context=context;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _context.ProductCategories.Select(c => new ProductCategoryQueryModel
            { 
                Id=c.Id,
                Name = c.Name,
                Picture=c.Picture,
                PictureAlt=c.PictureAlt,
                PictureTitle=c.PictureTitle,
                Slug=c.Slug
            }).ToList();
        }
    }
}

using _01_Query.Contract.Product;
using _01_Query.Contract.ProductCategory;
using Microsoft.EntityFrameworkCore;
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

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProduct()
        {
            return  _context.ProductCategories.Include(x=>x.products).ThenInclude(x=>x.Category).Select(x=>new ProductCategoryQueryModel 
            { 
                Id=x.Id,
                Name=x.Name,
                Products = MapProducts(x.products)
            }).ToList();
        }

        private static List<ProductQueryModel> MapProducts(List<ShopManagement.Domain.ProductAgg.Product> products)
        {
            var result = new List<ProductQueryModel>();
            foreach (var product in products)
            {
                var item = new ProductQueryModel
                {
                    Id = product.Id,
                    Category=product.Category.Name,
                    Name = product.Name,
                    Picture=product.Picture,
                    PictureAlt=product.PictureAlt,
                    PictureTitle =product.PictureTitle,
                    Slug =product.Slug
                };
                result.Add(item);
            }
            return result;
          
        }
    }
}

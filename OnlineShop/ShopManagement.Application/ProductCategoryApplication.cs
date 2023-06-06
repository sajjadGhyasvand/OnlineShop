using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository)
        {
            _productCategoryRepository= _productCategoryRepository;
        }
        public OprationResult Create(CreateProductCategory command)
        {
            var operation = new OprationResult();
            if (_productCategoryRepository.Exist(x=>x.Name == command.Name))
                return operation.Failed("امکان ثبت رکورد تکراری وجود ندارد");
            var slug = command.Slug.Slugify();
            var productCategory = new ProductCategory(command.Name,command.Picture,command.Description,
               command.MetaDescription,command.PictureTitle,command.PictureAlt,command.KeyWords, slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.saveChanges();
            return operation.succedded();
        }

        public OprationResult Edit(EditProductCategory command)
        {
            var operation = new OprationResult();
            var slug = command.Slug.Slugify();
            var productionCategory =_productCategoryRepository.GetById(command.Id);
            if (productionCategory != null)
                return operation.Failed("یافت نشد");
            if (_productCategoryRepository.Exist(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed("یافت نشد");
            productionCategory.Edit(command.Name, command.Picture, command.Description,
               command.MetaDescription, command.PictureTitle, command.PictureAlt, command.KeyWords,
               slug);
            _productCategoryRepository.saveChanges();
            return operation.succedded();

        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}

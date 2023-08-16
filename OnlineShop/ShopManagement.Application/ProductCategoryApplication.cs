
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
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository= productCategoryRepository;
            _fileUploader=fileUploader;
        }
        public OprationResult Create(CreateProductCategory command)
        {
            var operation = new OprationResult();
            if (_productCategoryRepository.Exists(x=>x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);
            var productCategory = new ProductCategory(command.PictureTitle, fileName, command.Description, command.PictureAlt, command.Name,
               command.KeyWords,command.MetaDescription, slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Edit(EditProductCategory command)
        {
            var operation = new OprationResult();
            var slug = command.Slug.Slugify();
            var productionCategory =_productCategoryRepository.Get(command.Id);
            if (productionCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.RecordNotFound);
            var picturePath = $"{command.Slug}";
            var fileName = _fileUploader.Upload(command.Picture,picturePath);
            productionCategory.Edit(command.PictureTitle, command.PictureAlt, fileName , command.Description, command.Name,
               command.KeyWords,  command.MetaDescription,   slug);
            _productCategoryRepository.SaveChanges();
            return operation.succedde();

        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
           return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}

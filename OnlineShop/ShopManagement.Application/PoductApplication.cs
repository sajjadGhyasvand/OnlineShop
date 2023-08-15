using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class PoductApplication : IPorductApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public PoductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository=productRepository;
            _fileUploader=fileUploader;
            _productCategoryRepository=productCategoryRepository;
        }

        public OprationResult Create(CreateProduct command)
        {
            var operation = new OprationResult();
            var categorySlug = _productCategoryRepository.GetSlugById(command.CategoryId);
            var path = $"{categorySlug}//{command.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var product = new Product(command.Name,command.Code,
                                      picturePath, command.PictureAlt,command.PictureTitle,
                                      command.Description,command.CategoryId,slug, 
                                      command.Keywords,command.MetaDescription,command.ShortDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.succedde();
        } 
        public OprationResult Edit(EditProduct command)
        {
            var operation = new OprationResult();
            var product = _productRepository.GetProductWithCategory(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound); 
            var slug = command.Slug.Slugify();
            if (_productRepository.Exists(x=>x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"{product.Category.Slug}//{command.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            product.Edit(command.Name,command.Code,command.UnitPrice,
                command.ShortDescription, picturePath, command.PictureAlt, command.PictureTitle,
                command.Description,slug, command.Keywords, command.MetaDescription);
            _productRepository.SaveChanges();
            return operation.succedde();
        }
        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}

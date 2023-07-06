using _0_Framework.Application;
using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
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

        public PoductApplication(IProductRepository productRepository)
        {
            _productRepository=productRepository;
        }

        public OprationResult Create(CreateProduct command)
        {
            var operation = new OprationResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var product = new Product(command.Name,command.Code,command.UnitPrice,
                                      command.Picture,command.PictureAlt,command.PictureTitle,
                                      command.Description,command.CategoryId,slug, 
                                      command.Keywords,command.MetaDescription,command.ShortDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.succedded();
        } 
        public OprationResult Edit(EditProduct command)
        {
            var operation = new OprationResult();
            var product = _productRepository.Get(command.Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound); 
            var slug = command.Slug.Slugify();
            if (_productRepository.Exists(x=>x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            product.Edit(command.Name,command.Code,command.UnitPrice,
                command.ShortDescription,command.Picture, command.PictureAlt, command.PictureTitle,
                command.Description,slug, command.Keywords, command.MetaDescription);
            _productRepository.SaveChanges();
            return operation.succedded();
        }
        public EditProduct GetDetails(long id)
        {
            return _productRepository.GetDetails(id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OprationResult InStock(long id)
        {
            var operation = new OprationResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.InStock();
           _productRepository.SaveChanges();
            return operation.succedded();
        }

        public OprationResult NotInStock(long Id)
        {
            var operation = new OprationResult();
            var product = _productRepository.Get(Id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            product.NotInStock();
            _productRepository.SaveChanges();
            return operation.succedded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}

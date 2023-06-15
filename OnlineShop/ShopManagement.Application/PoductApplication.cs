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
            var product = new Product(command.Name,command.Code,command.UnitPrice,command.Picture,command.PictureAlt,command.PictureTitle,command.Description,command.CategoryId,slug, command.Keywords,command.MetaDescription);
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
            product.Edit(command.Name,command.Code,command.UnitPrice, command.Picture, command.PictureAlt, command.PictureTitle, command.Description,slug, command.Keywords, command.MetaDescription);
            _productRepository.SaveChanges();
            return operation.succedded();
        }

        public OprationResult GetDetails(long id)
        {
            throw new NotImplementedException();
        }

        public void InStock(long id)
        {
            throw new NotImplementedException();
        }

        public void NotInStock(long Id)
        {
            throw new NotImplementedException();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            throw new NotImplementedException();
        }
    }
}

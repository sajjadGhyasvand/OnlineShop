using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.PoductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductRepository _productRepository;
        private readonly IPoductPictureRepository _productPictureRepository;
        private readonly IFileUploader _fileUploader;
        public ProductPictureApplication(IPoductPictureRepository productPictoreRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictoreRepository;
            _productRepository=productRepository;
            _fileUploader=fileUploader;
        }
        public OprationResult Create(CreatePoductPicture command)
        {
            var operation = new OprationResult();
            var product = _productRepository.GetProductWithCategory(command.ProductId);
            var path = $"{product.Category.Slug}//{product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            var productPicture = new ProductPicture(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Edit(EditPoductPicture command)
        {
            var operation = new OprationResult();
            var productPicture = _productPictureRepository.GetWithProductAndCategory(command.Id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            var path = $"{productPicture.Product.Category.Slug}//{productPicture.Product.Slug}";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            productPicture.Edit(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.succedde();
        }

        public EditPoductPicture GetDetails(long id)
        {
           return _productPictureRepository.GetDetails(id);
        }

        public OprationResult Remove(long id)
        {
            var operation = new OprationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Restore(long id)
        {
            var operation = new OprationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.succedde();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.search(searchModel);

        }
    }
}

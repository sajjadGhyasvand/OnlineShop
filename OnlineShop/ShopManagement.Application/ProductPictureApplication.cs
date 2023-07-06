using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.PoductPicture;
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
        private readonly IPoductPictureRepository _productPictureRepository;
        public ProductPictureApplication(IPoductPictureRepository productPictoreRepository)
        {
            _productPictureRepository = productPictoreRepository;
        }
        public OprationResult Create(CreatePoductPicture command)
        {
            var operation = new OprationResult();
            if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var productPicture = new ProductPicture(command.ProductId, command.Picture, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.succedded();
        }

        public OprationResult Edit(EditPoductPicture command)
        {
            var operation = new OprationResult();
            var productPicture = _productPictureRepository.Get(command.Id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.Id == command.Id)) 
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            productPicture.Edit(command.ProductId, command.Picture ,command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.succedded();
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
            return operation.succedded();
        }

        public OprationResult Restore(long id)
        {
            var operation = new OprationResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.succedded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.search(searchModel);

        }
    }
}

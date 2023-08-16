using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class SlideApplication : ISlideApplication
    {
        private readonly ISlideRepository _slideRepository;
        private readonly IFileUploader _fileUploader;

        public SlideApplication(ISlideRepository slideRepository, IFileUploader fileUploader)
        {
            _slideRepository=slideRepository;
            _fileUploader=fileUploader;
        }

        public OprationResult Create(CreateSlide command)
        {
            var operation = new OprationResult();


            var pictureName = _fileUploader.Upload(command.Picture, "slides");
            var slide = new Slide(pictureName, command.PictureAlt, command.PictureTitle,
               command.Heading, command.Title, command.Text,command.Link, command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Edit(EditSlide command)
        {
           var operation = new OprationResult();
           var slide = _slideRepository.Get(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            var pictureName = _fileUploader.Upload(command.Picture, "slides");

            slide.Edit(pictureName, command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.Link,command.BtnText);
            _slideRepository.SaveChanges();
            return operation.succedde();
        }

        public EditSlide GetDetails(long id)
        {
            return _slideRepository.GetDetails(id);
        }

        public List<SlideViewModel> GetList()
        {
            return _slideRepository.GetList();
        }

        public OprationResult Remove(long id)
        {
            var operation = new OprationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Remove();
            _slideRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Restore(long id)
        {
            var operation = new OprationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.succedde();
        }
    }
}

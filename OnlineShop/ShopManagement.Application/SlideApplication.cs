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

        public SlideApplication(ISlideRepository slideRepository)
        {
            _slideRepository=slideRepository;
        }

        public OprationResult Create(CreateSlide command)
        {
            var operation = new OprationResult();
            var slide = new Slide(command.Picture, command.PictureAlt, command.PictureTitle,
               command.Heading, command.Title, command.Text,command.Link, command.BtnText);
            _slideRepository.Create(slide);
            _slideRepository.SaveChanges();
            return operation.succedded();
        }

        public OprationResult Edit(EditSlide command)
        {
           var operation = new OprationResult();
           var slide = _slideRepository.Get(command.Id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
              slide.Edit(command.Picture,command.PictureAlt,command.PictureTitle,command.Heading,command.Title,command.Text,command.Link,command.BtnText);
            _slideRepository.SaveChanges();
            return operation.succedded();
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
            return operation.succedded();
        }

        public OprationResult Restore(long id)
        {
            var operation = new OprationResult();
            var slide = _slideRepository.Get(id);
            if (slide == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            slide.Restore();
            _slideRepository.SaveChanges();
            return operation.succedded();
        }
    }
}

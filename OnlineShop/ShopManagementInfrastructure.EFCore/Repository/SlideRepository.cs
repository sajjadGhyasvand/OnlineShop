using _0_FrameWork.Infrastructure;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagementInfrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long,Slide>,ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context=context;
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x=> new EditSlide 
            { 
                Id = x.Id,
                BtnText = x.BtnText,
                Heading = x.Heading,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                Text = x.Text,
                Link = x.Link,
                Title = x.Title
            }).FirstOrDefault(x=>x.Id==id);
        }

        public List<SlideViewModel> GetList()
        {
           return _context.Slides.Select(x=> new SlideViewModel 
           { 
            Id = x.Id,
            Picture = x.Picture,
            Title = x.Title,
            Heading = x.Heading,
            IsRemoved = x.IsRemoved,
            CreationDate = x.CreationDate.ToString()
           }).OrderByDescending(x=>x.Id).ToList();
        }
    }
}

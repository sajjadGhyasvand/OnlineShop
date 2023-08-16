using _0_FrameWork.Application;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Slide
{
    public class CreateSlide
    {
        public IFormFile Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Heading { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Title { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Text { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string BtnText { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string Link { get;  set; }
    }
}

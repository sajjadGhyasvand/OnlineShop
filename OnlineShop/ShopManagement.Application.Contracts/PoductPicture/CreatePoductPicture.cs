

using _0_FrameWork.Application;
using ShopManagement.Application.Contracts.Product;
using System.ComponentModel.DataAnnotations;

namespace ShopManagement.Application.Contracts.PoductPicture
{
    public class CreatePoductPicture
    {
        [Range(1,10000,ErrorMessage =ValidationMessages.IsRequired)]
        public long ProductId { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string Picture { get;  set; }
        [Required(ErrorMessage = ValidationMessages.IsRequired)]
        public string PictureAlt { get;  set; }
        [Required(ErrorMessage =ValidationMessages.IsRequired)]
        public string PictureTitle { get;  set; }
        public List<ProductViewModel> Products { get;  set; }
    }
}

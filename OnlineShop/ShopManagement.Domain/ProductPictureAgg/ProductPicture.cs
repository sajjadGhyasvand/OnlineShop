using _0_FrameWork.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductPictureAgg
{
    public class ProductPicture : EntityBase
    {
        public long ProductId { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public bool IsRemoved { get; set; }
        public ProductPicture(long productId, string picture, string pictureAlt, string pictureTitle)
        {
            ProductId=productId;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
        }

        public void Remove()
        {
            IsRemoved=true;
        }
        public void Restore()
        {
            IsRemoved = false;
        }
    }
}

using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductCategoryAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Domain.ProductAgg
{
    public class Product : EntityBase
    {

        public string Name { get; private set; }
        public string Code { get; private set; }
        public string ShortDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string MetaDescription { get; private set; }
        public List<ProductPicture> ProductPictures { get; set; }

        public ProductCategory Category { get; private set; }

        public long CategoryId { get; private set; }



        public Product(string name, string code, string picture, string pictureAlt, string pictureTitle, string description, long categoryId, string slug, string keywords, string metaDescription, string shortDescription)
        {
            Name=name;
            Code=code;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            Description=description;
            CategoryId=categoryId;
            Slug=slug;
            Keywords=keywords;
            MetaDescription=metaDescription;
            ShortDescription=shortDescription;
        }


        public void Edit(string name, string code,
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords,
            string metaDescription, long categoryId)
        {
            Name=name;
            ShortDescription=shortDescription;
            Description=description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            Slug=slug;
            Keywords=keywords;
            MetaDescription=metaDescription;
            Code=code;
            CategoryId=categoryId;
        }
    }
}

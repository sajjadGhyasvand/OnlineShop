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
        public double UnitPrice { get; private set; }
        public bool IsInStock { get; private set; } = true;
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

        

        public Product(string name, string code, double unitPrice, string picture, string pictureAlt, string pictureTitle, string description, long categoryId, string slug, string keywords, string metaDescription,string shortDescription)
        {
            Name=name;
            Code=code;
            UnitPrice=unitPrice;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            Description=description;
            CategoryId=categoryId;
            Slug=slug;
            Keywords=keywords;
            MetaDescription=metaDescription;
            ShortDescription=shortDescription;
            IsInStock = true;
        }


        public void Edit(string name, string code, double unitPrice,
            string shortDescription, string description, string picture,
            string pictureAlt, string pictureTitle, string slug, string keywords,
            string metaDescription)
        {
            Name=name;
            UnitPrice=unitPrice;
            ShortDescription=shortDescription;
            Description=description;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            Slug=slug;
            Keywords=keywords;
            MetaDescription=metaDescription;
            Code=code;
        }
        public void InStock()
        {
            this.IsInStock=true;
        }
        public void NotInStock()
        {
            IsInStock=false;
        }
    }
}

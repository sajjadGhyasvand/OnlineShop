using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _0_FrameWork.Domain;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.ProductCategoryAgg
{
    public class ProductCategory : EntityBase
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string KeyWords { get; private set; }
        public string MetaDescription { get; private set; }
        public string Slug { get; private set; }
        public List<Product> products { get; set; }

        public ProductCategory()
        {
            products = new();
        }

        public ProductCategory(string pictureTitle, string pictureAlt, string picture, string description, string name, string keyWords, string metaDescription, string slug)
        {
            Name=name;
            Description=description;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            KeyWords=keyWords;
            MetaDescription=metaDescription;
            Slug=slug;
        }
        public void Edit(string pictureTitle, string pictureAlt, string picture, string description, string name, string keyWords, string metaDescription, string slug)
        {
            Name=name;
            Description=description;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            KeyWords=keyWords;
            MetaDescription=metaDescription;
            Slug=slug;
        }
    }
}

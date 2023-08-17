using _0_FrameWork.Domain;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        public string Title { get; private set; }
        public string? ShortDescription { get; private set; }
        public string MetaDescription { get; private set; }
        public string Description { get; private set; }
        public string Picture { get; private set; }
        public string PictureAlt { get; private set; }
        public string PictureTitle { get; private set; }
        public string Slug { get; private set; }
        public string Keywords { get; private set; }
        public string CanonicalAddress { get; private set; }
        public DateTime  PublishDate { get; set; }
        public long CategoryId { get; private set; }
        public ArticleCategory Category { get; private set; }

        public Article(string title, string description,
            string picture, string pictureAlt, string pictureTitle,
            string slug, string keywords, string canonicalAddress, long categoryId, DateTime publishDate)
        {
            Title=title;
            Description=description;
            Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            Slug=slug;
            Keywords=keywords;
            CanonicalAddress=canonicalAddress;
            CategoryId=categoryId;
            PublishDate=publishDate;
        }
        public void Edit(string title, string description,
            string picture, string pictureAlt, string pictureTitle,
            string slug, string keywords, string canonicalAddress, long categoryId, DateTime publishDate)
        {
            Title=title;
            Description=description;
            if (!string.IsNullOrWhiteSpace(picture))
                Picture=picture;
            PictureAlt=pictureAlt;
            PictureTitle=pictureTitle;
            Slug=slug;
            Keywords=keywords;
            CanonicalAddress=canonicalAddress;
            CategoryId=categoryId;
            PublishDate=publishDate;
        }
    }
}

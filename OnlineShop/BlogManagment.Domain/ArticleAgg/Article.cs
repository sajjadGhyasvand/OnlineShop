using _0_FrameWork.Domain;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Domain.ArticleAgg
{
    public class Article : EntityBase
    {
        [Required]
        public string Title { get;  set; }
        public string? ShortDescription { get;  set; }
        public string MetaDescription { get;  set; }
        [Required]
        public string Description { get;  set; }
        public string Picture { get;  set; }
        public string PictureAlt { get;  set; }
        public string PictureTitle { get;  set; }
        public string Slug { get;  set; }
        public string Keywords { get;  set; }
        public string CanonicalAddress { get;  set; }
        [Required]
        public DateTime  PublishDate { get; set; }
        public long CategoryId { get;  set; }
        public ArticleCategory Category { get;  set; }

        



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

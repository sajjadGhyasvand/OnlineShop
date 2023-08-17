﻿using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Application.Contracts.Article
{
    public class CreateArticle
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string MetaDescription { get; set; }
        public string Description { get; set; }
        public IFormFile Picture { get; set; }
        public string PictureAlt { get; set; }
        public string PictureTitle { get; set; }
        public string Slug { get; set; }
        public string Keywords { get; set; }
        public string CanonicalAddress { get; set; }
        public string PublishDate { get; set; }
        public long CategoryId { get; set; }
    }
}

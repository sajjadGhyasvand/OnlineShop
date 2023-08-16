using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Application.Contracts.ArticleCategory
{
    public class CreateArticleCategory
    {
        public string Name { get;  set; }
        public IFormFile Picture { get;  set; }
        public string Description { get;  set; }
        public string ShowOrder { get;  set; }
        public string Slug { get; set; }
        public string KeyWords { get; set; }
        public string MetaDescription { get; set; }
        public string CanonicalAddress { get; set; }
    }
}

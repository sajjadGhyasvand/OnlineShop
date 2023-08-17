using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using BlogManagment.Application.Contracts.Article;
using BlogManagment.Domain.ArticleAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    internal class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    {
        private readonly BlogContext _context;

        public ArticleRepository(BlogContext context) : base(context)
        {
            _context=context;
        }

        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(a => new EditArticle { 
            CanonicalAddress = a.CanonicalAddress,
            CategoryId = a.CategoryId,
            Description = a.Description,
            Keywords = a.Keywords,  
            MetaDescription = a.MetaDescription,
            PictureAlt = a.PictureAlt,
            PictureTitle = a.PictureTitle,
            PublishDate = a.PublishDate.ToFarsi(),
            ShortDescription = a.ShortDescription,
            Slug = a.Slug,
            Title = a.Title,
            }).FirstOrDefault(a => a.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel { 
            Id = x.Id,
            Category = x.Category.Name,
            Title = x.Title,
            CategoryId=x.CategoryId,
            Picture = x.Picture,
            PublishDate= x.PublishDate.ToFarsi(),
            ShortDescription = x.ShortDescription      
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Title))
                query = query.Where(x => x.Title.Contains(searchModel.Title));
            if(searchModel.CategoryId > 0)
                query=query.Where(x=>x.CategoryId == searchModel.CategoryId);
            return query.OrderByDescending(x=>x.Id).ToList();

        }
    }
}

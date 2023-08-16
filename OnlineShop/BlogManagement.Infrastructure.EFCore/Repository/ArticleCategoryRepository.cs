using _0_FrameWork.Infrastructure;
using BlogManagment.Application.Contracts.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleCategoryRepository : RepositoryBase<long, ArticleCategory>, IArticleCategoryRepository
    {
        private readonly BlogContext _context;

        public ArticleCategoryRepository(BlogContext context) : base(context)
        {
            _context=context;
        }

        public EditArticleCategory GetDetails(long id)
        {
            return _context.ArticleCategories.Select(c => new EditArticleCategory { 
            Id = c.Id,
            Name = c.Name,
            CanonicalAddress = c.CanonicalAddress,
            Description = c.Description,
            KeyWords = c.KeyWords,
            MetaDescription = c.MetaDescription,
            ShowOrder = c.ShowOrder,
            Slug = c.Slug
            }).FirstOrDefault(c => c.Id == id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
            var query = _context.ArticleCategories.Select(x => new ArticleCategoryViewModel { 
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
                ShowOrder =x.ShowOrder,
                Picture = x.Picture
            });
            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x=>x.Name.Contains(searchModel.Name));
            return query.OrderByDescending(x=>x.ShowOrder).ToList();
        }
    }
}

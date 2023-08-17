using _0_Framework.Application;
using _0_FrameWork.Application;
using _0_FrameWork.Infrastructure;
using BlogManagment.Application.Contracts.Article;
using BlogManagment.Domain.ArticleAgg;
using BlogManagment.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Infrastructure.EFCore.Repository
{
    public class ArticleRepository : RepositoryBase<long, Article>, IArticleRepository
    { 
        private readonly IFileUploader _fileUploader;
        private readonly BlogContext _context;
        private readonly IArticleCategoryRepository _articleCategopryRepository;
        public ArticleRepository(BlogContext context, IArticleCategoryRepository articleCategopryRepository, IFileUploader fileUploader) : base(context)
        {
            _context=context;
            _articleCategopryRepository=articleCategopryRepository;
            _fileUploader=fileUploader;
        }

        public Article CreateArticle(CreateArticle commad)
        {
            var slug = commad.Slug.Slugify();
            var categorySlug = _articleCategopryRepository.GetSlugById(commad.CategoryId);
            var path = $"{categorySlug}/{slug}";
            var pictureName = _fileUploader.Upload(commad.Picture, path);
            var publishDate = commad.PublishDate.ToGeorgianDateTime();
            var article = new Article() {
                Title=commad.Title,
                Description=commad.Description,
                Picture=pictureName,
                PictureAlt=commad.PictureAlt,
                PictureTitle=commad.PictureTitle,
                Slug=slug,
                Keywords=commad.Keywords,
                CanonicalAddress=commad.CanonicalAddress,
                CategoryId=commad.CategoryId,
                PublishDate=publishDate,
                MetaDescription = commad.MetaDescription
            };
            return article;         
        }
        
        public EditArticle GetDetails(long id)
        {
            return _context.Articles.Select(a => new EditArticle
            {
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

        public Article GetWithCategory(long id)
        {
            return _context.Articles.Include(x=>x.Category).FirstOrDefault(x => x.Id == id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            var query = _context.Articles.Select(x => new ArticleViewModel
            {
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
            if (searchModel.CategoryId > 0)
                query=query.Where(x => x.CategoryId == searchModel.CategoryId);
            return query.OrderByDescending(x => x.Id).ToList();

        }
    }
}

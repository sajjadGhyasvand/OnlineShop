﻿using _0_FrameWork.Application;
using _01_LampshadeQuery.Contract.Comment;
using _01_Query.Contract.Article;
using BlogManagement.Infrastructure.EFCore;
using CommentManagement.Infrastructure.EfCore;
using Microsoft.EntityFrameworkCore;

namespace _01_Query.Contract.Query
{
    public class ArticleQuery : IArticleQuery
    {
        private readonly BlogContext _context;
        private readonly CommentContext _commentContext;

        public ArticleQuery(BlogContext context, CommentContext commentContext)
        {
            _context = context;
            _commentContext = commentContext;
        }

        public ArticleQueryModel GetArticleDetails(string slug)
        {
            var article2 = _context.Articles.ToList();
            var article = _context.Articles
               .Include(x => x.Category)
               /*.Where(x => x.PublishDate <= DateTime.Now)*/
               .Select(x => new ArticleQueryModel
               {
                   Id = x.Id,
                   Title = x.Title,
                   CategoryName = x.Category.Name,
                   CategorySlug = x.Category.Slug,
                   Slug = x.Slug,
                   CanonicalAddress = x.CanonicalAddress,
                   Description = x.Description,
                   Keywords = x.Keywords,
                   MetaDescription = x.MetaDescription,
                   Picture = x.Picture,
                   PictureAlt = x.PictureAlt,
                   PictureTitle = x.PictureTitle,
                   PublishDate = x.PublishDate.ToFarsi(),
                   ShortDescription = x.ShortDescription,
               }).FirstOrDefault(x => x.Slug == slug);

            if (!string.IsNullOrWhiteSpace(article.Keywords))
                article.KeywordList = article.Keywords.Split(",").ToList();


              var comments = _commentContext.Comments
                  .Where(x => !x.IsCanceled)
                  .Where(x => x.IsConfirmed)
                  .Where(x => x.Type == CommentType.Article)
                  .Where(x => x.OwnerRecordId == article.Id)
                  .Select(x => new CommentQueryModel
                  {
                      Id = x.Id,
                      Message = x.Message,
                      Name = x.Name,
                      ParentId = x.ParentId,
                      CreationDate = x.CreationDate.ToFarsi()
                  }).OrderByDescending(x => x.Id).ToList();

              foreach (var comment in comments)
              {
                  if (comment.ParentId > 0)
                      comment.parentName = comments.FirstOrDefault(x => x.Id == comment.ParentId)?.Name;
              }

              article.Comments = comments;
            
            return article;
        }

        public List<ArticleQueryModel> LatestArticles()
        {
            return _context.Articles
                .Include(x => x.Category)
                /*.Where(x => x.PublishDate <= DateTime.Now)*/
                .Select(x => new ArticleQueryModel
                {
                    Title = x.Title,
                    Slug = x.Slug,
                    Picture = x.Picture,
                    PictureAlt = x.PictureAlt,
                    PictureTitle = x.PictureTitle,
                    PublishDate = x.PublishDate.ToFarsi(),
                    ShortDescription = x.ShortDescription,
                }).ToList();
        }
    }
}

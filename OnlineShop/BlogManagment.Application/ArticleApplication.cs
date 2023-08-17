using _0_Framework.Application;
using _0_FrameWork.Application;
using BlogManagment.Application.Contracts.Article;
using BlogManagment.Domain.ArticleAgg;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Application
{
    public class ArticleApplication : IArticleApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IArticleRepository _articleRepository;
        private readonly IArticleCategoryRepository _articleCategopryRepository;

        public ArticleApplication(IArticleRepository articleRepository, IFileUploader fileUploader, IArticleCategoryRepository articleCategopryRepository)
        {
            _articleRepository=articleRepository;
            _fileUploader=fileUploader;
            _articleCategopryRepository=articleCategopryRepository;
        }

        public OprationResult Create(CreateArticle command)
        {
            var operation = new OprationResult();
            if (_articleRepository.Exists(x => x.Title == command.Title))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var article = _articleRepository.CreateArticle(command);
            _articleRepository.Create(article);
            _articleRepository.SaveChanges();
            return operation.succedde();
        }

        public OprationResult Edit(EditArticle command)
        {
            var operation = new OprationResult();
            var article = _articleRepository.GetWithCategory(command.Id);
            if (article == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            if (_articleRepository.Exists(x => x.Title == command.Title && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var path = $"{article.Category.Slug}/{slug}";
            var pictureName = _fileUploader.Upload(command.Picture, path);
            var publishDate = command.PublishDate.ToGeorgianDateTime();
            article.Edit(command.Title,command.Description,pictureName,command.PictureAlt,command.PictureTitle,command.Slug,command.Keywords,command.CanonicalAddress,command.CategoryId,publishDate);
            _articleRepository.SaveChanges();
            return operation.succedde();

        }

        public EditArticle GetDetails(long id)
        {
            return _articleRepository.GetDetails(id);
        }

        public List<ArticleViewModel> Search(ArticleSearchModel searchModel)
        {
            return _articleRepository.Search(searchModel);
        }
    }
}

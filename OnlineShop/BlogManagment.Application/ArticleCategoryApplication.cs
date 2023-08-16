using _0_Framework.Application;
using _0_FrameWork.Application;
using BlogManagment.Application.Contracts.ArticleCategory;
using BlogManagment.Domain.ArticleCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Application
{
    public class ArticleCategoryApplication : IArticleCategoryApplication
    {
        private readonly IArticleCategoryRepository _articleCategoryRepository;
        private readonly IFileUploader _fileUploader;

        public ArticleCategoryApplication(IArticleCategoryRepository articleCategoryRepository, IFileUploader fileUploader)
        {
            _articleCategoryRepository=articleCategoryRepository;
            _fileUploader=fileUploader;
        }

        public OprationResult Create(CreateArticleCategory command)
        {
            var operation = new OprationResult();
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture,slug);
            var articleCategory = new ArticleCategory(command.Name, pictureName, command.Description, command.ShowOrder, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);
            _articleCategoryRepository.Create(articleCategory);
            _articleCategoryRepository.SaveChanges();
            return operation.succedde();

        }

        public OprationResult Edit(EditArticleCategory command)
        {
            var operation = new OprationResult();
            var articleCategory = _articleCategoryRepository.Get(command.Id);
            if (articleCategory == null)
                return operation.succedde(ApplicationMessages.RecordNotFound);
            if (_articleCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);
            var slug = command.Slug.Slugify();
            var pictureName = _fileUploader.Upload(command.Picture, slug);
            articleCategory.Edit(command.Name, pictureName, command.Description, command.ShowOrder, slug, command.KeyWords, command.MetaDescription, command.CanonicalAddress);

            _articleCategoryRepository.SaveChanges();
            return operation.succedde();
        }

        public EditArticleCategory GetDetails(long id)
        {
           return _articleCategoryRepository.GetDetails(id);
        }

        public List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel)
        {
          return _articleCategoryRepository.Search(searchModel);
        }
    }
}

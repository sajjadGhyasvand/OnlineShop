using _0_FrameWork.Domain;
using BlogManagment.Application.Contracts.ArticleCategory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagment.Domain.ArticleCategoryAgg
{
    public interface IArticleCategoryRepository : Irepository<long, ArticleCategory>
    {
        List<ArticleCategoryViewModel> GetArticleCategories();
        string GetSlugById(long id);
        List<ArticleCategoryViewModel> Search(ArticleCategorySearchModel searchModel);
        EditArticleCategory GetDetails(long id);    
    }
}

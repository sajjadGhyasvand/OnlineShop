using _01_Query.Contract.Article;
using _01_Query.Contract.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class ArticleModel : PageModel
    {
        public ArticleQueryModel Article;
        public List<ArticleQueryModel> LatestArticles;
        public List<ArticleCategoryQueryModel> ArticleCategories;
        private readonly IArticleQuery _articleQuery;
        private readonly IArticleCategoryQuery _articleCategoryQuery;
       /* private readonly ICommentApplication _commentApplication;*/

        public ArticleModel(IArticleQuery articleQuery, IArticleCategoryQuery articleCategoryQuery/*, ICommentApplication commentApplication*/)
        {
            _articleQuery = articleQuery;
            /*_commentApplication = commentApplication;*/
            _articleCategoryQuery = articleCategoryQuery;
        }

        public void OnGet(string id)
        {
            Article = _articleQuery.GetArticleDetails(id);
            LatestArticles = _articleQuery.LatestArticles();
            ArticleCategories = _articleCategoryQuery.GetArticleCategories();
        }

        public IActionResult OnPost(/*AddComment command,*/ string articleSlug)
        {
            /*command.Type = CommentType.Article;
            var result = _commentApplication.Add(command);*/
            return RedirectToPage("/Article", new { Id = articleSlug });
        }
    }
}

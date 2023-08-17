using BlogManagment.Application.Contracts.Article;
using BlogManagment.Application.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ServiceHost.Areas.Administration.Pages.Blog.Articles
{
    public class CreateModel : PageModel
    {
        public SelectList ArticleCategories;
        public CreateArticle Command;
        private readonly IArticleCategoryApplication _articleCategoryApplication;
        private readonly IArticleApplication _articleApplication;

        public CreateModel(IArticleCategoryApplication articleCategoryApplication, IArticleApplication articleApplication)
        {
            _articleCategoryApplication=articleCategoryApplication;
            _articleApplication=articleApplication;
        }

        public void OnGet()
        {
            ArticleCategories = new SelectList(_articleCategoryApplication.GetArticleCategories(),"Id","Name");
        }
        public IActionResult OnPost(CreateArticle command)
        {
            var result = _articleApplication.Create(command);
            return RedirectToPage("./Index");
        }
    }
}

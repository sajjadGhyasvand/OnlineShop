using BlogManagment.Application.Contracts.ArticleCategory;

namespace BlogManagment.Application.Contracts.Article
{
    public class ArticleSearchModel
    {
        public string Title { get; set; }
        public long CategoryId { get; set; }
    }
}

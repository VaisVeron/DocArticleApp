using DocArticleApp.Models;

namespace DocArticleApp
{
    public interface IArticleService
    {
        List<ArticleModel> GetArticles();
    }
}

using DocArticleApp.Models;

namespace DocArticleApp
{
    public interface IDocumentService
    {
        byte[] GetDocument(List<ArticleModel> articles);
    }
}

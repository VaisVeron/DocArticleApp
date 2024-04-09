using DocArticleApp.Models;

namespace DocArticleApp
{
    public class ArticleService : IArticleService
    {
        private readonly ILogger<ArticleService> _logger;
        private static List<ArticleModel> _articles;

        public ArticleService(ILogger<ArticleService> logger)
        {
            logger = _logger;
        }

        public List<ArticleModel> GetArticles()
        {
            if (_articles == null)
            {
                _articles = new List<ArticleModel>();
                for (var i = 0; i < 10; i++)
                {
                    _articles.Add(new ArticleModel()
                    {
                        Id = Guid.NewGuid(),
                        Name = $"Article {i}",
                        Text = $"Article {i} text. " +
                               @"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et 
                                dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip 
                                ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu 
                                fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt 
                                mollit anim id est laborum."
                    });
                }
            }
            return _articles;
        }
    }
}

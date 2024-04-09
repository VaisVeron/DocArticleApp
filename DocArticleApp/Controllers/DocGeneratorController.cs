using DocArticleApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DocArticleApp.Controllers
{
    public class DocGeneratorController : Controller
    {
        private readonly ILogger<DocGeneratorController> _logger;
        private readonly IArticleService _articleService;
        private readonly IDocumentService _documentService;

        public DocGeneratorController(
            ILogger<DocGeneratorController> logger, 
            IArticleService articleService,
            IDocumentService documentService)
        {
            _logger = logger;
            _articleService = articleService;
            _documentService = documentService;
        }

        public IActionResult Index()
        {
            var articlesSelectListItems = new List<SelectListItem>();

            var articles = _articleService.GetArticles();

            foreach (var article in articles)
            {
                SelectListItem selectList = new SelectListItem()
                {
                    Text = article.Name,
                    Value = article.Id.ToString(),
                    Selected = false
                };
                articlesSelectListItems.Add(selectList);
            }

            ArticlesViewModel articlesViewModel = new ArticlesViewModel()
            {
                Articles = articlesSelectListItems
            };

            return View(articlesViewModel);
        }

        [HttpPost]
        public ActionResult Index(IEnumerable<string> selectedArticles)
        {
            var articles = _articleService.GetArticles()
                .Where(a => selectedArticles.Contains(a.Id.ToString()))
                .ToList();

            var document = _documentService.GetDocument(articles);

            return File(document, System.Net.Mime.MediaTypeNames.Application.Octet, $"Doc_{DateTime.Now.ToShortTimeString()}.docx");
        }
    }
}

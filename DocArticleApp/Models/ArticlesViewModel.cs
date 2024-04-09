using Microsoft.AspNetCore.Mvc.Rendering;

namespace DocArticleApp.Models
{
    public class ArticlesViewModel
    {
        public IEnumerable<Guid> SelectedArticles { get; set; }
        public IEnumerable<SelectListItem> Articles { get; set; }
    }
}

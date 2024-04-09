using DocArticleApp.Models;
using NPOI.SS.Formula;
using NPOI.XWPF.UserModel;

namespace DocArticleApp
{
    public class DocumentService: IDocumentService
    {
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(ILogger<DocumentService> logger)
        {
            logger = _logger;
        }

        public byte[] GetDocument(List<ArticleModel> articles)
        {
            using (XWPFDocument document = new XWPFDocument())
            {
                foreach (var article in articles)
                {
                    var paragraph = document.CreateParagraph();
                    paragraph.Alignment = ParagraphAlignment.CENTER;
                    //paragraph.BorderBottom = Borders.Double;
                    //paragraph.BorderTop = Borders.Double;
                    
                    //paragraph.BorderRight = Borders.Double;
                    //paragraph.BorderLeft = Borders.Double;
                    //paragraph.BorderBetween = Borders.Single;
                    paragraph.VerticalAlignment = TextAlignment.TOP;

                    XWPFRun run = paragraph.CreateRun();
                    run.SetText(article.Text);
                    run.IsBold = true;
                    run.FontFamily = "Courier";
                    //run.Underline = UnderlinePatterns.DotDotDash;
                    run.TextPosition = 100;
                }

                using (MemoryStream generatedDocument = new MemoryStream())
                {
                    document.Write(generatedDocument);
                    return generatedDocument.ToArray();
                }
            }
        }
    }
}

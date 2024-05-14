using DotAir.API.Template;
using DotAir.BLL.Infrastructure;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SelectPdf;

namespace DotAir.API.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class DocumentController(HtmlToPdf _htmlToPdf, HtmlRenderer _renderer) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetFile()
        {
            string html = _renderer.Render<Example>(new
            {
                Age = 42,
                Reference = "My ref",
                IsAdmin = false,
                Values = new int[] { 1, 2, 3 },
            });

            PdfDocument document = _htmlToPdf.ConvertHtmlString(html);
            return File(document.Save(), "application/pdf", "myFile.pdf");
        }
    }
}

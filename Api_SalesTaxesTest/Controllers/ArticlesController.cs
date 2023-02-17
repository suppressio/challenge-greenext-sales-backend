using Api_SalesTaxesTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_SalesTaxesTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticlesController : Controller
    {

        [HttpGet(Name = "GetAvailableArticles")]
        public IEnumerable<Article> GetArticles()
        {
            return ArticlesStorage.GetArticles();
        }

        [HttpGet(Name = "GetArticles")]
        public IActionResult GetArt(int idArt)
        {
            Article? art = ArticlesStorage.GetArticlesDetails(idArt);
            if (art == null)
                return NotFound();

            return Ok(art);
        }
    }
}

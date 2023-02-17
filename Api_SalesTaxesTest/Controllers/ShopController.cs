using Api_SalesTaxesTest.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api_SalesTaxesTest.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        const string SessionKey = "ShoppingCartSessionStorage_Key123";

        [HttpGet(Name = "GetCart")]
        public ShoppingCart GetShCart()
        {
            return ShoppingCartSessionStorage.Get(HttpContext.Session, SessionKey);
        }

        [HttpGet(Name = "AddToCart")]
        public IActionResult AddToShCart(int idArt, int qty)
        {
            Article? art = ArticlesStorage.GetArticlesDetails(idArt);
            if (art == null)
                return NotFound();

            ShoppingCart shCart = ShoppingCartSessionStorage.Get(HttpContext.Session, SessionKey);
            int counter = ShoppingCartSessionStorage.GetCounter(HttpContext.Session, SessionKey);

            counter = shCart.Add(art, qty, counter);

            ShoppingCartSessionStorage.Set(HttpContext.Session, SessionKey, shCart);
            ShoppingCartSessionStorage.SetCounter(HttpContext.Session, SessionKey, counter);

            return Ok();
        }

        [HttpGet(Name = "RemoveFromCart")]
        public IActionResult RemToShCart(int idShoppedArt, int qty)
        {
            ShoppingCart shCart = ShoppingCartSessionStorage.Get(HttpContext.Session, SessionKey);

            var shoppedArticle = shCart.Get(idShoppedArt);
            if (shoppedArticle == null)
                return NotFound();

            if (shCart.Remove(shoppedArticle, qty))
                BadRequest("Qty not valid: "+ qty);

            ShoppingCartSessionStorage.Set(HttpContext.Session, SessionKey, shCart);

            return Ok();
        }

        [HttpGet(Name = "SetNewCart")]
        public ShoppingCart SetNewCart()
        {
            ShoppingCart oldCart = ShoppingCartSessionStorage.Get(HttpContext.Session, SessionKey);

            ShoppingCart newCart = new()
            {
                Id = oldCart.Id + 1
            };

            ShoppingCartSessionStorage.Set(HttpContext.Session, SessionKey, newCart);
            ShoppingCartSessionStorage.SetCounter(HttpContext.Session, SessionKey, 0);

            return newCart;
        }



        [HttpGet(Name = "GetReceipt")]
        public Receipt GetReceipt()
        {
            ShoppingCart cart = ShoppingCartSessionStorage.Get(HttpContext.Session, SessionKey);

            return new Receipt(cart);
        }
    }
}

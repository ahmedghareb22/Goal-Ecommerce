

using Microsoft.AspNetCore.Authorization;

namespace Goal.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

       
        public JsonResult GetCart()
        {
            int userId = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cart = _cartRepository.GetCart(userId);
            return Json(cart);
        }

        public JsonResult AddToCart(int productId)
        {
            int userId = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            _cartRepository.Add(userId, productId);
            return Json(new { success = true });
        }
        public JsonResult changeQuantity(int itemId, int amount)
        {
            _cartRepository.Update(itemId,amount);
            return Json(new { success = true });
        }


        [HttpPost]
        public JsonResult DeleteItem(int itemId)
        {
            _cartRepository.Delete(itemId);
            return Json(new { success = true });
        }
    }

}

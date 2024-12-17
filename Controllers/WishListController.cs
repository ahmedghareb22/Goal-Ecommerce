using Microsoft.AspNetCore.Authorization;

namespace Goal.Controllers
{
    [Authorize]
    public class WishListController : Controller
    {
        private readonly IWishListRepository wishListRepository;
        public WishListController(IWishListRepository wishListRepository)
        {
            this.wishListRepository = wishListRepository;
        }
        // GET: WishListController
        [AllowAnonymous]
        public IActionResult WishList() {
            int Id = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var Product = wishListRepository.GetWishListProducts(Id);
            return View(Product);
        }
        /*public JsonResult GetWishList()
        {
            int Id = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var Product = wishListRepository.GetWishListProducts(Id);
            return Json(Product);
        }*/
        public IActionResult Delete(int id) {
            int Id = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            
            wishListRepository.Delete(Id,id);
            return RedirectToAction("WishList");
        }
        public JsonResult AddToWish(int id)
        {
            int Id = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            wishListRepository.Add(Id, id);
            return Json(new { success = true });
        }
        
          
 
    }
}

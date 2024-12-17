
using Goal.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Goal.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ShopController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public IActionResult Index()
        {
            var products = _productRepository.GetAll();
            return View(products);
        }
        public IActionResult Filter(int CategoryId, int BrandId, int MinPrice, int MaxPrice)
        {
            var products = _productRepository.GetFilterProduct(CategoryId,BrandId,MinPrice,MaxPrice);
            return Json(products);
        }
        public IActionResult Single(int id)
        {
           Product product= _productRepository.GetById(id);
            return View(product);
        }




    }
}

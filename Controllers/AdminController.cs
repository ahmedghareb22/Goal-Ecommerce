namespace Goal.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository adminRepository;
        private readonly IProductRepository productRepository;

        public AdminController(IAdminRepository adminRepository,IProductRepository productRepository)
        {
            this.adminRepository = adminRepository;
            this.productRepository = productRepository;
        }
        public IActionResult AdminDashBord()
        {
            ViewBag.dashboard = "active";
            var i = adminRepository.GetValues();
            return View(i);
        }
        public IActionResult CustomerDashBord()
        {
            var customers = adminRepository.GetCustomer();
            ViewBag.customers = "active";
            return View(customers); 
        }
        public IActionResult Contact() 
        {
            List<Contact> contact = adminRepository.contacts();
            ViewBag.messages = "active";
            return View(contact);
        }
        [HttpPost]
        public IActionResult DeleteContact(int id)
        {
            adminRepository.DelContact(id);
            return RedirectToAction("Contact");
        }
        public IActionResult Product(Product? product)
        {
            ProductViewModel productViewModel = new ProductViewModel
            {
                Products = productRepository.GetAll() ,
                product = product
            }; 
            ViewBag.products = "active";
            return View(productViewModel);
        }
        public IActionResult AddProduct(Product product)
        {
            
                // Ensure Photos are passed correctly
                if (product.Photo == null || product.Photo.Count == 0)
                {
                    return BadRequest("At least one image is required.");
                }

            // Add product
            if (product.Id != 0)
                productRepository.AddProduct(product);
            else
                productRepository.UpdateProduct(product);

            return RedirectToAction("Product");
        }
        public IActionResult Update(int id)
        {
           var i = productRepository.GetById(id);
            return RedirectToAction("Product", i);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            try
            {
                productRepository.DeleteProduct(id);
                return RedirectToAction("Product");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

    }
}

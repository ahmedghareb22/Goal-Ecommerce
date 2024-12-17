// This example sets up an endpoint using the ASP.NET MVC framework.
// Watch this video to get started: https://youtu.be/2-mMOB8MhmE.

using Stripe;
using Stripe.Checkout;

namespace server.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly AppDpContext _Context;
        private readonly ICartRepository cartRepository;

        public PaymentsController(AppDpContext appDpContext, ICartRepository cartRepository)
        {
            this._Context = appDpContext;
            this.cartRepository = cartRepository;
        }
        public IActionResult Index()
        {
            int id = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var cart = cartRepository.GetCart(id);
            if (cart.Items.Count() != 0)
            {
                ViewBag.Cart = cart.Items;
                ViewBag.Total = _Context.Items.Sum(e => e.Quntity * e.Product.Price);

                return View();
            }
            return RedirectToAction("Index", "Shop");
        }


        [HttpPost]
        public IActionResult SavePayment(Payment payment)
        {
            
            int id = int.Parse(User?.FindFirst(ClaimTypes.NameIdentifier)?.Value);
            var IsIN = _Context.Payments.Where(e => e.AccountNum == payment.AccountNum && e.CustomerId == id).FirstOrDefault();
            if (IsIN == null)
            {
                payment.CustomerId = id;
                _Context.Add(payment);
                _Context.SaveChanges();
            }
            IsIN = _Context.Payments.Where(e => e.AccountNum == payment.AccountNum && e.CustomerId == id).FirstOrDefault();
            int payID = IsIN.Id;
            var cart = cartRepository.GetCart(id);
            var items = cart.Items;
            var total = _Context.Items.Where(e => e.CartId == cart.Id).Sum(e => e.Quntity * e.Product.Price);
            Order order = new Order
            {
                CustomerId = id,
                paymentId= payID,
                Total = total
            };
            _Context.Orders.Add(order);
            _Context.SaveChanges();
            var orders = _Context.Orders.Where(c => c.CustomerId == id && c.paymentId == payID).FirstOrDefault();
            int orderId = orders.Id;


            
            foreach (var item in items)
            {
                var q = new Item
                {
                    Id = item.Id,
                    CartId = null,
                    OrderId = orderId,
                    ProductId = item.Product.Id,
                    Quntity=item.Quntity

                };
                
                _Context.Items.Update(q);
            }
            _Context.SaveChanges();

            return RedirectToAction("Index","Home");

        }
    }
}

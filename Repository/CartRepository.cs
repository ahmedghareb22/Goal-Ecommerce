

namespace Goal.Repository
{
    [Authorize]
    public class CartRepository : ICartRepository
    {
        private readonly AppDpContext _context;
        public CartRepository(AppDpContext context)
        {
            _context = context;
        }
        public Cart GetCart(int id)
        {
            var cart = _context.Carts
                        .Include(c => c.Items) 
                        .ThenInclude(i => i.Product)
                        .ThenInclude(p => p.Imgs) 
                        .Where(c => c.CustomerId == id) 
                        .Select(c => new Cart
                        {
                            Id = c.Id,
                            CustomerId = c.CustomerId,
                            Items = c.Items.Select(item => new Item
                            {
                                Id = item.Id,
                                Product = new Product
                                {
                                    Id = item.Product.Id,
                                    Name = item.Product.Name,
                                    Imgs = item.Product.Imgs,
                                    Price = item.Product.Price
                                },
                                Quntity = item.Quntity 
                            }).ToList()
                        })
                        .FirstOrDefault(); 

            return cart;
            
        }
        public void Add(int Id, int ProductId)
        {
            var CartId = _context.Carts.Where(c => c.CustomerId == Id).FirstOrDefault();
            var Item = _context.Items.Where(e => e.ProductId == ProductId && e.CartId == CartId.Id).FirstOrDefault();

            if (Item == null)
            { 
                Item item = new Item { CartId = CartId.Id, ProductId = ProductId };
                _context.Add(item);
                _context.SaveChanges();
                
            }
            else
            {
                Update(Item.Id,1);
            }
        }
 
        public bool Update(int ItemId,int amount)
        {
            var Item = _context.Items.Find(ItemId);
            var Check = StockCheck(Item.ProductId);
            if (Item.Quntity == 1 && amount == -1)
            {
                Delete(ItemId);
                return true;
            }
            if (Check)
            {
                Item.Quntity += amount;
                _context.Update(Item);
                _context.SaveChanges();
            }
            return Check;
        }


        public void Delete(int ItemId)
        {
            var Item = _context.Items.Find(ItemId);
            _context.Remove(Item);
            _context.SaveChanges();
        }
        public bool StockCheck(int productId)
        {
            var product = _context.Products.Find(productId);
            var Stock =_context.Stocks.Find(product.StockId);
            if (Stock.Quantity > 0)
                return true;
            return false;

        }

        
    }
}


using Goal.Models;

namespace Goal.Repository
{
    public class WishListRepository : IWishListRepository
    {
        private readonly AppDpContext _context;
        public WishListRepository(AppDpContext context)
        {
            _context = context;
        }
        public void Add(int UserId,int ProductId)
        {
            int WishListId = Get(UserId).Id;
            ProductWishList ProductWishList = productWishList(ProductId, WishListId);
            _context.ProductWishLists.Add(ProductWishList);
            _context.SaveChanges();
            
        }

        public void Delete(int UserId, int ProductId)
        {
            int WishListId = Get(UserId).Id;
            ProductWishList ProductWishList = productWishList(ProductId, WishListId);
            _context.ProductWishLists.Remove(ProductWishList);
            _context.SaveChanges();
        }

        public WishList Get(int CustomerId)
        {
            WishList WishList = _context.WishLists.Where(e => e.CustomerId == CustomerId).FirstOrDefault();
            return WishList;
        }
        public ProductWishList productWishList(int ProductId, int WishListId)
        {
            ProductWishList ProductWishList = new ProductWishList { ProductId = ProductId, WishListId = WishListId };
            return ProductWishList;
        }
        public List<WishList> GetWishListProducts(int UserId)
        {
            int WishListId = Get(UserId).Id;
            var i = _context.WishLists
                .Include(p=> p.productsWish)
                .ThenInclude(w=>w.Product)
                .ThenInclude(i=>i.Imgs)
                .Where(u=>u.Id == WishListId)
                .AsNoTracking()
                .ToList();
            return i;
        }
    }
}

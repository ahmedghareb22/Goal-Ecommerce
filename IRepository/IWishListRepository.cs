using Goal.Models;

namespace Goal.IRepository
{
    public interface IWishListRepository
    {
        public void Add(int UserId, int ProductId);
        public void Delete(int UserId, int ProductId);
        public WishList Get(int CustomerId);
        public List<WishList> GetWishListProducts(int UserId);
    }
}

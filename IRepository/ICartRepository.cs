namespace Goal.IRepository
{
    public interface ICartRepository
    {
        public Cart GetCart(int id);
        public void Add(int Id, int ProductId);
        public bool Update(int ItemId, int amount);
        public void Delete(int Id);

    }
}

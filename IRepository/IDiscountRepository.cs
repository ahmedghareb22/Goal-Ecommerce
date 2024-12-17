using Goal.Models;

namespace Goal.IRepository
{
    public interface IDiscountRepository
    {
        public void Add(Discount discount);
        public void Delete(int id);
        public Discount GetById(int id);
        public List<Discount> GetAll();
        public void Update(Discount category);
        public void Save();
    }
}

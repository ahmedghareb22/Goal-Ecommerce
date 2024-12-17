using Goal.Models;

namespace Goal.IRepository
{
    public interface ICtegoryRepository
    {
        public void Add(Category category);
        public void Delete(int id);
        public Category GetById(int id);
        public List<Category> GetAll();
        public void Update(Category category);
        public void Save();
    }
}

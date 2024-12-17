using Goal.Models;

namespace Goal.IRepository
{
    public interface IBrandRepository
    {
        public void Add(Brand brand);
        public void Delete(int id);
        public Category GetById(int id);
        public List<Brand> GetAll();
        public void Update(Brand brand);
        public void Save();
    }
}

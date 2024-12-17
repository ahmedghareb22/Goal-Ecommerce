using Goal.Data;
using Goal.IRepository;
using Goal.Models;

namespace Goal.Repository
{
    public class BrandRepository : IBrandRepository
    {
        private AppDpContext _Context;
        public BrandRepository(AppDpContext context)
        {
            _Context = context;
        }
        public void Add(Brand brand)
        {
            _Context.Brands.Add(brand);   
        }

        public void Delete(int id)
        {
            Brand brand = GetById(id);
            _Context.Brands.Remove(brand);
        }

        public List<Brand> GetAll()
        {
           List<Brand> brands= _Context.Brands.ToList();
           return brands;
        }

        public Brand GetById(int id)
        {
            Brand brands = _Context.Brands.Find(id);
            return brands;
        }

        public void Save()
        {
            _Context.SaveChanges();
        }

        public void Update(Brand brand)
        {
            _Context.Brands.Update(brand);
        }

        Category IBrandRepository.GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}

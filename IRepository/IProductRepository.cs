
namespace Goal.IRepository
{
    public interface IProductRepository
    {
        /*public void Add(Product product);*/
        public void UpdateProduct(Product updatedProduct);
        public void DeleteProduct(int productId);
        public Product GetById(int id);
        public List<Product> GetAll();
        public List<Product> GetFilterProduct(int CategoryId, int BrandId, int MinPrice, int MaxPrice);
        public void AddImages(List<IFormFile> photos, int productId);
        public void AddProduct(Product product);
        public void Save();

    }
}

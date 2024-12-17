namespace Goal.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDpContext _context;
        private readonly IWebHostEnvironment _environment;
        public ProductRepository(AppDpContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _environment = hostEnvironment;
        }
        /*public void AddImge(List<IFormFile> imgs, Product id)
        {
            Img i = new Img();
            Product h= _context.Products.Where(e=>e == id).FirstOrDefault();
            i.ProductId = h.Id;
            foreach (IFormFile im in imgs)
            {
                var uploadFolder = Path.Combine(_environment.WebRootPath, "img");
                i.Name= im.FileName;
                var fullPath = Path.Combine(uploadFolder,im.FileName);
                im.CopyTo(new FileStream(fullPath, FileMode.Create));


*//*                _context.Imgs.Add(i);
*//*            }
        }*/
        public void AddImage(List<IFormFile> imgs, int productId)
        {
            Product product = _context.Products.FirstOrDefault(e => e.Id == productId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            foreach (IFormFile img in imgs)
            {
                // إنشاء كائن الصورة
                Img image = new Img
                {
                    ProductId = product.Id,
                    Name = img.FileName
                };

                // تحديد المسار الكامل للملف
                var uploadFolder = Path.Combine(_environment.WebRootPath, "img");
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(img.FileName); // استخدام GUID لاسم فريد
                var fullPath = Path.Combine(uploadFolder, fileName);

                // التأكد من وجود المجلد
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                // نسخ الملف إلى المجلد
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    img.CopyTo(fileStream);
                }

                // إضافة الصورة إلى السياق
                image.Name = fileName; // تأكد من أن اسم الصورة يكون المسار الفعلي للملف
                _context.Imgs.Add(image);
            }

            // حفظ التغييرات في قاعدة البيانات
            _context.SaveChanges();
        }

        /*public void Add(Product product)
        {
            Stock stock =new Stock();
            stock.Quantity = product.Stock.Quantity;

            foreach(var img in product.Photo)
            {
                var i = new Img { 
                    Name = img.FileName
                };
                product.Imgs.Add()

            }

            _context.Products.Add(product);
            _context.SaveChanges();


            AddImge(product.Imgs,product);
            _context.Products.Add(product);
        }*/

        public void AddImages(List<IFormFile> photos, int productId)
        {
            // Validate that the product exists
            var product = _context.Products.FirstOrDefault(p => p.Id == productId);
            if (product == null)
                throw new Exception("Product not found");

            // Define the upload folder
            var uploadFolder = Path.Combine(_environment.WebRootPath, "img");
            if (!Directory.Exists(uploadFolder))
            {
                Directory.CreateDirectory(uploadFolder);
            }

            foreach (var photo in photos)
            {
                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                var fullPath = Path.Combine(uploadFolder, fileName);

                // Save the file to the server
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    photo.CopyTo(fileStream);
                }

                // Add image to the database
                Img image = new Img
                {
                    ProductId = productId,
                    Name = fileName
                };
                _context.Imgs.Add(image);
            }

            _context.SaveChanges(); // Save all images
        }







        public void AddProduct(Product product)
        {
            product.BrandId = 1;
            // Check if the required Brand and Category exist
            if (!_context.Brands.Any(b => b.Id == product.BrandId))
                throw new Exception("Brand not found");

            if (!_context.Categories.Any(c => c.Name == product.Category.Name))
                throw new Exception("Category not found");

            // Set default timestamps
            product.CreateAt = DateTime.Now;
            product.ModifiedAt = DateTime.Now;

            // Add Stock if provided
            if (product.Stock != null)
            {
                _context.Stocks.Add(product.Stock);
                _context.SaveChanges(); // Save Stock and auto-generate StockId
                product.StockId = product.Stock.Id; // Set StockId in Product
            }

            // Add the Product and save to generate Product.Id
            _context.Products.Add(product);
            _context.SaveChanges(); // After this, product.Id is populated

            // If photos are provided, handle image uploads
            if (product.Photo != null && product.Photo.Count > 0)
            {
                AddImages(product.Photo, product.Id); // Use the generated Product.Id
            }

            // Final save (if necessary, but usually not needed here)
            _context.SaveChanges();
        }
        public void UpdateProduct(Product updatedProduct)
        {
            // Find the existing product by Id
            var existingProduct = _context.Products
                                          .Include(p => p.Imgs)
                                          .Include(p => p.Stock)
                                          .FirstOrDefault(p => p.Id == updatedProduct.Id);

            if (existingProduct == null)
            {
                throw new Exception("Product not found");
            }

            // Update basic fields
            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;
            existingProduct.DiscountId = updatedProduct.DiscountId;
            existingProduct.ModifiedAt = DateTime.Now;

            // Update Stock if provided
            if (updatedProduct.Stock != null)
            {
                if (existingProduct.Stock != null)
                {
                    existingProduct.Stock.Quantity = updatedProduct.Stock.Quantity;
                }
                else
                {
                    existingProduct.Stock = updatedProduct.Stock;
                }
            }

            // Handle new images
            if (updatedProduct.Photo != null && updatedProduct.Photo.Count > 0)
            {
                // Optionally delete old images
                foreach (var img in existingProduct.Imgs)
                {
                    var imgPath = Path.Combine(_environment.WebRootPath, "img", img.Name);
                    if (File.Exists(imgPath))
                    {
                        File.Delete(imgPath);
                    }
                    _context.Imgs.Remove(img);
                }

                // Add new images
                AddImages(updatedProduct.Photo, existingProduct.Id);
            }

            // Save changes
            _context.SaveChanges();
        }




        public void DeleteProduct(int productId)
        {
            // Find the product by Id, including related images and stock
            var product = _context.Products
                                  .Include(p => p.Imgs)
                                  .Include(p => p.Stock)
                                  .FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("Product not found");
            }

            // Delete associated images from storage and database
            foreach (var img in product.Imgs)
            {
                var imgPath = Path.Combine(_environment.WebRootPath, "img", img.Name);
                if (File.Exists(imgPath))
                {
                    File.Delete(imgPath);
                }
                _context.Imgs.Remove(img);
            }

            // Remove associated stock if it exists
            if (product.Stock != null)
            {
                _context.Stocks.Remove(product.Stock);
            }

            // Delete the product
            _context.Products.Remove(product);

            // Save changes to the database
            _context.SaveChanges();
        }




















        public void Delete(int id)
        {
            Product product = GetById(id);
            product.Name = "Item";
            Update(product);
        }

        public List<Product> GetAll()
        {
            
            List<Product> products = _context.Products
                .Where(p => p.Name != "Item")
                .Include(c=>c.Category)
                .Include(e=>e.Brand)
                .Include(I => I.Imgs)
                .Include(s=>s.Stock)
                .AsNoTracking()
                .ToList();
            return products;
        }
        public List<Product> GetFilterProduct(int CategoryId, int BrandId, int MinPrice, int MaxPrice)
        {
            var Query = _context.Products
                .Where(p=>p.Name != "Item")
				.Include(c => c.Category)
				.Include(e => e.Brand)
				.Include(I => I.Imgs)
                .Select(p=> new Product {
                   Id = p.Id,
                    Name =p.Name,
                    Price = p.Price,
                    Imgs = p.Imgs,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId
                                        }
                    )
				.AsQueryable();
            if(CategoryId != 0)
                Query= Query.Where(C=>C.CategoryId == CategoryId);
            if (BrandId != 0)
                Query = Query.Where(B => B.BrandId == BrandId);
            if (MinPrice != 0)
                Query = Query.Where(P => P.Price >= MinPrice);
            if (MaxPrice != 0)
                Query = Query.Where(P => P.Price <= MaxPrice);
            var FilterProduct = Query.ToList();
            return FilterProduct;

        }

        public Product GetById(int id)
        {
            var Query = _context.Products
                .Where(p => p.Name != "Item")
                .Include(c => c.Category)
                .ThenInclude(c=>c.Products)
                .ThenInclude(i=>i.Imgs)
                .Include(b => b.Brand)
                .Include(I => I.Imgs)
                .Select(p => new Product
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Imgs = p.Imgs,
                    Descreption = p.Descreption,
                    Category = p.Category,
                    BrandId = p.BrandId,
                    CategoryId = p.CategoryId
                }
                    ).AsNoTracking()
                    .Where(e=> e.Id==id);
            Product Product = Query.SingleOrDefault();
            return Product;
        }
        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Product product)
        {
            
        }

    }
}

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace Goal.Data;

public partial class AppDpContext : IdentityDbContext<AppUser, AppRole, int>
{


    public AppDpContext(DbContextOptions<AppDpContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<Cart> Carts { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Discount> Discounts { get; set; }

    public virtual DbSet<Img> Imgs { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }


    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductWishList> ProductWishLists { get; set; }

    public virtual DbSet<Stock> Stocks { get; set; }

    public virtual DbSet<UserAddress> UserAddresses { get; set; }

    public virtual DbSet<WishList> WishLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductWishList>()
            .HasKey(pw => new { pw.ProductId, pw.WishListId });

        modelBuilder.Entity<ProductWishList>()
            .HasOne(pw => pw.Product)
            .WithMany(p => p.wishLists)
            .HasForeignKey(pw => pw.ProductId);

        modelBuilder.Entity<ProductWishList>()
            .HasOne(pw => pw.WishList)
            .WithMany(w => w.productsWish)
            .HasForeignKey(pw => pw.WishListId);

        base.OnModelCreating(modelBuilder);
    }
}

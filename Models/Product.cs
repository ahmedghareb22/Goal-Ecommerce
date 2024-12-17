namespace Goal.Models;

[Table("Product")]
public partial class Product
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string Name { get; set; } = null!;

    [Column("descreption")]
    [Unicode(false)]
    public string? Descreption { get; set; } = "Hala Madrid";

    [Column("price", TypeName = "decimal(18, 0)")]
    public decimal Price { get; set; }

    [Column("brandId")]
    public int BrandId { get; set; }

    [Column("categoryId")]
    public int CategoryId { get; set; }

    [Column("discountId")]
    public int? DiscountId { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }

    public int? StockId { get; set; }

    
    public virtual Brand Brand { get; set; } = null!;

    
    public virtual Category Category { get; set; } = null!;

    
    public virtual Discount? Discount { get; set; }

    public virtual List<Img> Imgs { get; set; } = new List<Img>();
    public List<ProductWishList> wishLists { get; set; }

    public virtual Stock? Stock { get; set; }
    [NotMapped]
    public List<IFormFile> Photo { get; set; }
}

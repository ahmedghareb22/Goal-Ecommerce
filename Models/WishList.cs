

namespace Goal.Models;

[Table("WishList")]
public partial class WishList
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }

    public List<ProductWishList> productsWish { get; set; }
    public virtual AppUser Customer { get; set; } = null!;
}

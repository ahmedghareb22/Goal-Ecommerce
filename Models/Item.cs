
namespace Goal.Models;

[Table("Item")]
public partial class Item
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("productId")]
    public int ProductId { get; set; }

    [Column("quntity")]
    public int Quntity { get; set; } = 1;

    [Column("cartId")]
    public int? CartId { get; set; }

    [Column("orderId")]
    public int? OrderId { get; set; }

    public virtual Cart? Cart { get; set; }


    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; } = null!;
}

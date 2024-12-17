namespace Goal.Models;

[Table("Cart")]
public partial class Cart
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; } = DateTime.Now;

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }


    public virtual AppUser Customer { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();
}

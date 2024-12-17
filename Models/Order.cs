namespace Goal.Models;

public partial class Order
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("total", TypeName = "decimal(18, 2)")]
    public decimal Total { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; } =DateTime.Now;

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }
    public int paymentId { get; set; }

    public bool IsCash { get; set; }
    public virtual AppUser Customer { get; set; } = null!;

    public virtual ICollection<Item> Items { get; set; } = new List<Item>();

    public virtual Payment payments { get; set; }
}



namespace Goal.Models;

[Table("Payment")]
public partial class Payment
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("provider")]
    [StringLength(255)]
    [Unicode(false)]
    [Required]
    public string Provider { get; set; } = null!;

    [Column("accountNum")]
    [StringLength(16)]
    [Unicode(false)]
    [Required]
    public string AccountNum { get; set; } = null!;



    [Column("expiry")]
    [Unicode(false)]
    [Required]
    public DateOnly Expiry { get; set; }

    [Required]
    public string CVV { get; set; }



    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; } = DateTime.Now;

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }

    public virtual AppUser Customer { get; set; } = null!;

    public virtual ICollection<Order> Orders { get; set; }
}


namespace Goal.Models;

[Table("Contact")]
public partial class Contact
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; } = DateTime.Now;

    [Column("name")]
    [StringLength(30)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("email")]
    [StringLength(100)]
    [Unicode(false)]
    public string? Email { get; set; }

    [Column("content")]
    [Unicode(false)]
    public string? Content { get; set; }

    public virtual  AppUser Customer { get; set; } = null!;
}

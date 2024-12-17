using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Goal.Models;

[Table("Img")]
public partial class Img
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("name")]
    [StringLength(255)]
    [Unicode(false)]
    public string? Name { get; set; }

    [Column("productId")]
    public int ProductId { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }

    public virtual Product Product { get; set; } = null!;
}

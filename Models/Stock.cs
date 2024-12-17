using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Goal.Models;

[Table("Stock")]
public partial class Stock
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("quantity")]
    public int? Quantity { get; set; }

    [Column("soldNum")]
    public int? SoldNum { get; set; }

    [Column("createAt", TypeName = "datetime")]
    public DateTime? CreateAt { get; set; }

    [Column("modifiedAt", TypeName = "datetime")]
    public DateTime? ModifiedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}

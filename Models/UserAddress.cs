using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Goal.Models;

[Table("UserAddress")]
public partial class UserAddress
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("customerId")]
    public int CustomerId { get; set; }

    [Column("adress")]
    [StringLength(255)]
    [Unicode(false)]
    public string Adress { get; set; } = null!;

    [Column("city")]
    [StringLength(100)]
    [Unicode(false)]
    public string? City { get; set; }


    public virtual AppUser Customer { get; set; } = null!;
}

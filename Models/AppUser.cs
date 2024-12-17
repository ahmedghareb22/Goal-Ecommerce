using Microsoft.AspNetCore.Identity;

namespace Goal.Models
{
    public class AppUser:IdentityUser<int>
    {
        
        public string FullName { get; set; }
        public DateOnly? BirthDate { get; set; }

        [Unicode(false)]
        public string? Img { get; set; }

        [Column("createAt", TypeName = "datetime")]
        public DateTime? CreateAt { get; set; } = DateTime.Now;

        [Column("modifiedAt", TypeName = "datetime")]
        public DateTime? ModifiedAt { get; set; }
        public virtual Cart Carts { get; set; }

        public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

        public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();

        public virtual UserAddress UserAddresses { get; set; }

        public virtual WishList WishLists { get; set; }

    }

}



namespace Goal.Models;
[Table("ProductWishList")]
public partial class ProductWishList
{
    
    public int WishListId { get; set; }
    
    public int ProductId { get; set; }

    public virtual Product Product { get; set; }

    public virtual WishList WishList { get; set; }
}

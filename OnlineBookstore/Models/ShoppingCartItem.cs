using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models;

public class ShoppingCartItem
{
    public int Id { get; set; }
    
    [Required]
    public string UserId { get; set; }
    
    [Required]
    public int BookId { get; set; }
    
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than zero")]
    public int Quantity { get; set; }
    
    public virtual Book Book { get; set; }
}
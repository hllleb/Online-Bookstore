using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.ViewModels;

public class BookViewModel
{
    public int Id { get; set; }
    
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Author { get; set; }
    
    [Required]
    [Range(0.01, double.MaxValue, ErrorMessage = "Price must be positive")]
    public decimal Price { get; set; }
    
    //public int CategoryId { get; set; }
    
    //public string CategoryName { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.ViewModels;

public class CategoryViewModel
{
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
}
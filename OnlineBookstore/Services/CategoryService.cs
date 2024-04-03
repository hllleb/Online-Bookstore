using OnlineBookstore.Models;

namespace OnlineBookstore.Services;

public class CategoryService
{
    private readonly ApplicationDbContext context;
    
    public CategoryService(ApplicationDbContext context)
    {
        this.context = context;
    }
}
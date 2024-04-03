using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineBookstore.Models;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Order> Orders { get; set; }

    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
}
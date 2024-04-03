using Microsoft.EntityFrameworkCore;
using OnlineBookstore.Models;

namespace OnlineBookstore.Services;

public class ShoppingCartService : IShoppingCartService
{
    private readonly ApplicationDbContext context;

    public ShoppingCartService(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    public void AddToCart(string userId, int bookId, int quantity)
    {
        var existingItem = this.context.ShoppingCartItems.FirstOrDefault(item => item.UserId == userId && item.BookId == bookId);
        if (existingItem != null)
        {
            existingItem.Quantity += quantity;
        }
        else
        {
            var newItem = new ShoppingCartItem
            {
                UserId = userId,
                BookId = bookId,
                Quantity = quantity
            };
            this.context.ShoppingCartItems.Add(newItem);
        }
        
        this.context.SaveChanges();
    }

    public void UpdateCartItem(string userId, int cartItemId, int quantity)
    {
        var item = this.context.ShoppingCartItems.FirstOrDefault(i => i.UserId == userId && i.Id == cartItemId);
        if (item != null)
        {
            item.Quantity = quantity;
            this.context.SaveChanges();
        }
    }

    public void RemoveFromCart(string userId, int cartItemId)
    {
        var item = this.context.ShoppingCartItems.FirstOrDefault(i => i.UserId == userId && i.Id == cartItemId);
        if (item != null)
        {
            this.context.ShoppingCartItems.Remove(item);
            this.context.SaveChanges();
        }
    }

    public List<ShoppingCartItem> GetCartItems(string userId)
    {
        return this.context.ShoppingCartItems
            .Where(item => item.UserId == userId)
            .Include(item => item.Book)
            .ToList();
    }
}
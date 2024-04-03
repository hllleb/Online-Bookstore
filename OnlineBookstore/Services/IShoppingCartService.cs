using OnlineBookstore.Models;

namespace OnlineBookstore.Services;

public interface IShoppingCartService
{
    void AddToCart(string userId, int bookId, int quantity);
    void UpdateCartItem(string userId, int cartItemId, int quantity);
    void RemoveFromCart(string userId, int cartItemId);
    List<ShoppingCartItem> GetCartItems(string userId);
}
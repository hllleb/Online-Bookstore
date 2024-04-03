using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using OnlineBookstore.Services;

namespace OnlineBookstore.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartService shoppingCartService;
    private readonly UserManager<ApplicationUser> userManager;

    public ShoppingCartController(IShoppingCartService shoppingCartService, UserManager<ApplicationUser> userManager)
    {
        this.shoppingCartService = shoppingCartService;
        this.userManager = userManager;
    }
    
    [Authorize]
    public IActionResult Index()
    {
        var userId = userManager.GetUserId(User);
        var cartItems = shoppingCartService.GetCartItems(userId);
        return View(cartItems);
    } 
    
    [HttpPost]
    [Authorize]
    public IActionResult AddToCart(int bookId, int quantity)
    {
        var userId = userManager.GetUserId(User);
        shoppingCartService.AddToCart(userId, bookId, quantity);
        return RedirectToAction("Index", "Home");
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult UpdateCartItem(int cartItemId, int quantity)
    {
        var userId = userManager.GetUserId(User);
        shoppingCartService.UpdateCartItem(userId, cartItemId, quantity);
        return RedirectToAction("Index");
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult RemoveFromCart(int cartItemId)
    {
        var userId = userManager.GetUserId(User);
        shoppingCartService.RemoveFromCart(userId, cartItemId);
        return RedirectToAction("Index");
    }
}
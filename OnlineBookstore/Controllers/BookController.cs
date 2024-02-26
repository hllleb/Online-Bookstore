using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class BookController : Controller
{
    private readonly ApplicationDbContext context;
    
    public BookController(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    // GET
    public IActionResult Index()
    {
        var books = this.context.Books.ToList();
        return View(books);
    }
}
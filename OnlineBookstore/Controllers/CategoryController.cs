using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class CategoryController : Controller
{
    private readonly ApplicationDbContext context;

    public CategoryController(ApplicationDbContext context)
    {
        this.context = context;
    }
    
    // GET
    public IActionResult Index()
    {
        var categories = this.context.Categories.ToList();
        return View(categories);
    }
}
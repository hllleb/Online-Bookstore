using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;

namespace OnlineBookstore.Controllers;

public class CategoriesController : Controller
{
    private readonly ApplicationDbContext context;

    public CategoriesController(ApplicationDbContext context)
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
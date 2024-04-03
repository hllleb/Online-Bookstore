using Microsoft.AspNetCore.Mvc;
using OnlineBookstore.Models;
using OnlineBookstore.ViewModels;
using OnlineBookstore.Services;

namespace OnlineBookstore.Controllers;

public class BooksController : Controller
{
    private readonly ApplicationDbContext context;
    private readonly BookService bookService;
    
    public BooksController(ApplicationDbContext context, BookService bookService)
    {
        this.context = context;
        this.bookService = bookService;
    }
    
    // GET
    public IActionResult Index()
    {
        var books = bookService.GetAll().Select(MapBook).ToList();
        return View(books);
    }

    public IActionResult Details(int id)
    {
        Book book;
        try
        {
            book = this.bookService.GetById(id);
        }
        catch (BookNotFoundException)
        {
            return NotFound();
        }

        var viewModel = MapBook(book);
        return View(viewModel);
    }

    public IActionResult Edit(int id)
    {
        Book book;
        try
        {
            book = this.bookService.GetById(id);
        }
        catch (BookNotFoundException)
        {
            return NotFound();
        }
        
        var model = MapBook(book);
        return View(model);
    }

    [HttpPost]
    public IActionResult Edit(BookViewModel model)
    {
        if (ModelState.IsValid)
        {
            var book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Price = model.Price,
            };

            if (this.bookService.Edit(book))
            {
                return RedirectToAction("Index", "Books");
            }
        }

        return View(model);
    }

    public IActionResult Delete(int id)
    {
        Book book;
        try
        {
            book = this.bookService.GetById(id);
        }
        catch (BookNotFoundException)
        {
            return NotFound();
        }

        var model = MapBook(book);
        return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        if (this.bookService.Remove(id))
        {
            return RedirectToAction("Index", "Books");
        }

        return NotFound();
    }

    public ActionResult<Book> Create()
    {
        var model = new BookViewModel();
        return View(model);
    }

    [HttpPost]
    public ActionResult Create(BookViewModel model)
    {
        if (ModelState.IsValid)
        {
            var book = new Book
            {
                Id = model.Id,
                Title = model.Title,
                Author = model.Author,
                Price = model.Price,
            };

            if (this.bookService.Add(book))
            {
                return RedirectToAction("Index", "Books");
            }
        }
        
        return View(model);
    }

    private static BookViewModel MapBook(Book book) =>
        new()
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            Price = book.Price,
        };
}
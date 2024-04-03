using OnlineBookstore.Models;

namespace OnlineBookstore.Services;

public class BookService
{
    private readonly ApplicationDbContext context;
    
    public BookService(ApplicationDbContext context)
    {
        this.context = context;
    }

    public Book GetById(int id)
    {
        if (id < 0)
        {
            throw new BookNotFoundException(id, "ID cannot be negative");
        }
        
        var book = this.context.Find<Book>(id);

        if (book is null)
        {
            throw new BookNotFoundException(id, "There is no such book");
        }
        
        return book;
    }

    public IList<Book> GetAll()
    {
        return this.context.Books.ToList();
    }

    public bool Remove(int id)
    {
        var book = this.context.Find<Book>(id);
        if (book is null)
        {
            return false;
        }
        
        this.context.Remove(book);
        return this.context.SaveChanges() > 0;
    }

    public bool Add(Book book)
    {
        this.context.Add(book);
        return this.context.SaveChanges() > 0;
    }

    public bool Edit(Book editedBook)
    {
        var book = this.context.Find<Book>(editedBook.Id);
        if (book is null)
        {
            throw new BookNotFoundException(editedBook.Id, "There is no such book");
        }

        book.Author = editedBook.Author;
        book.Title = editedBook.Title;
        book.Price = editedBook.Price;
        
        this.context.Update(book);
        return this.context.SaveChanges() > 0;
    }
}
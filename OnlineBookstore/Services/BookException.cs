namespace OnlineBookstore.Services;

public class BookNotFoundException : Exception
{
    public BookNotFoundException(int id, string message) : base(message)
    {
        this.Id = id;
    }
    
    public int Id { get; set; }
}
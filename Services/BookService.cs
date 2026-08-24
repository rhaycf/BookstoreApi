using Bookstore.Communication;
using Bookstore.Models;

namespace Bookstore.Services;

public class BookService
{
    private static readonly List<Book> books = [];

    public List<Book> GetAllBooks() => books;

    public Book? GetBookById(Guid id)
    {
        var book = books.FirstOrDefault(x => x.Id == id);
        return book;
    }

    public Book? UpdateBook(Guid id, UpdateBookRequest request)
    {
        var book = books.FirstOrDefault(b => b.Id == id);

        if (book == null) throw new ArgumentException("O livro não existe!");

        bool titleAndAuthorDuplicate = books.Any(
            b => b.Title.Equals(request.Title, StringComparison.OrdinalIgnoreCase) &&
            b.Author.Equals(request.Author, StringComparison.OrdinalIgnoreCase)
        );

        if (titleAndAuthorDuplicate)
            throw new ArgumentException("Este livro (título e o autor) já está cadastrado!");

        if (request.Title.Length < 2 || request.Title.Length > 120)
            throw new ArgumentException("Este título não pode possuir menos que 2 caracteres ou ser maior que 120 caracteres!");

        if (request.Author.Length < 2 || request.Author.Length > 120)
            throw new ArgumentException("Este autor não pode possuir menos que 2 caracteres ou ser maior que 120 caracteres!");

        ValidatePrice(request.Price);
        ValidateStock(request.Stock);

        book.Title = request.Title;
        book.Author = request.Author;
        book.Genre = request.Genre;
        book.Price = request.Price;
        book.Stock = request.Stock;

        return book;
    }

    public int DeleteBook(Guid id)
    {
        var delete = books.RemoveAll(book => book.Id == id);

        if (delete == 0) throw new ArgumentException("Nenhum livro encontrado!");

        return delete;
    }

    public Book CreateBook(CreateBookRequest request)
    {
        var newBook = new Book
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Author = request.Author,
            Genre = request.Genre,
            Price = request.Price,
            Stock = request.Stock
        };

        bool titleAndAuthorDuplicate = books.Any(
            b => b.Title.Equals(newBook.Title, StringComparison.OrdinalIgnoreCase) &&
            b.Author.Equals(newBook.Author, StringComparison.OrdinalIgnoreCase)
        );

        if (titleAndAuthorDuplicate)
            throw new ArgumentException("Este livro (título e o autor) já está cadastrado!");

        if (newBook.Title.Length < 2 || newBook.Title.Length > 120)
            throw new ArgumentException("Este título não pode possuir menos que 2 caracteres ou ser maior que 120 caracteres!");
        
        if (newBook.Author.Length < 2 || newBook.Author.Length > 120)
            throw new ArgumentException("Este autor não pode possuir menos que 2 caracteres ou ser maior que 120 caracteres!");

        ValidatePrice(newBook.Price);
        ValidateStock(newBook.Stock);

        books.Add(newBook);

        return newBook;
    }

    public void ValidatePrice(decimal price)
    {
        if (price < 0.0m)
            throw new ArgumentException("O preço não pode ser negativo!");
    }

    public void ValidateStock(int stock)
    {
        if (stock < 0)
            throw new ArgumentException("O estoque não pode ser negativo!");
    }
}

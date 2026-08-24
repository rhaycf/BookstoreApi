using Livraria.Models;
using Livraria.Utils.Enums;

namespace Livraria.Services;

public class CreateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public GenreEnum Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }

    public void ValidateTitle(Book book)
    {
        if (book.Title == Title)
            throw new ArgumentException("Não é permitido títulos duplicados!");
    }

    public void ValidateAuthor(Book book)
    {

    }

    public void ValidatePrice(Book book)
    {
        if (book.Price < 0.0m)
            throw new ArgumentException("O preço não pode ser negativo!");
    }

    public void ValidateStock(Book book)
    {
        if (book.Stock < 0)
            throw new ArgumentException("Não é permitido estoque negativo!");
    }
}

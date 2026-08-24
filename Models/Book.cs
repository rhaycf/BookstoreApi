using Livraria.Utils.Enums;

namespace Livraria.Models;

public class Book
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public GenreEnum Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock  { get; set; }
}

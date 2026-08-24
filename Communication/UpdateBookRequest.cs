using Livraria.Utils.Enums;

namespace Livraria.Communication;

public class UpdateBookRequest
{
    public string Title { get; set; } = string.Empty;
    public string Author { get; set; } = string.Empty;
    public GenreEnum Genre { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

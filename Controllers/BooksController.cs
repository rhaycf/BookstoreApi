using Bookstore.Communication;
using Bookstore.Models;
using Bookstore.Services;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

/// <summary>
/// Controller responsável pelo gerenciamento de livros.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly BookService bookService;

    public BooksController(BookService bookService)
    {
        this.bookService = bookService;
    }

    /// <summary>
    /// Lista todos os livros
    /// </summary>
    [HttpGet]
    [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAllBooks()
    {
        var allBooks = bookService.GetAllBooks();

        return Ok(allBooks);
    }

    /// <summary>
    /// Busca um livro pelo seu identificador
    /// </summary>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult GetBookById([FromRoute] Guid id)
    {
        var book = bookService.GetBookById(id);
        
        if (book == null) return NotFound();

        return Ok(book);
    }

    /// <summary>
    /// Cria um novo livro
    /// </summary>
    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult CreateBook([FromBody] CreateBookRequest request)
    {
        var createdBook = bookService.CreateBook(request);

        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    /// <summary>
    /// Atualiza informações de um livro
    /// </summary>
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public IActionResult UpdateBook(Guid id, [FromBody] UpdateBookRequest request)
    {
        bookService.UpdateBook(id, request);   

        return NoContent();
    }


    /// <summary>
    /// Exclui um livro da livraria
    /// </summary>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteBook(Guid id)
    {
        bookService.DeleteBook(id);

        return NoContent();
    }
}

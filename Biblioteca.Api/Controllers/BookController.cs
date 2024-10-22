using Biblioteca.Application.DTOs;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Biblioteca.Controllers;

[ApiController]
[Route("/api/[controller]s")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ActionResult<List<BookDto>>> GetAllBooks()
    {
        var books = await _bookService.GetAllBooksAsync();

        return Ok(books);
    }


    [HttpGet("{id:int}")]
    [Authorize]
    public async Task<ActionResult<BookDto>> GetBookById(int id)
    {
        try
        {
            var book = await _bookService.GetBookById(id);
            return Ok(book);
        }
        catch (DataNotFoundException e)
        {
            return NotFound(new { message = e.Message });
        }
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<BookDto>> CreateBook([FromBody] BookDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new {message = ModelState});
        }

        var book = await _bookService.CreateBook(dto);

        return CreatedAtAction(nameof(GetBookById), new { id = book.Id}, book);
    }

    [HttpPut("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult<BookDto>> UpdateBook(int id, [FromBody] BookDto dto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(new { message = ModelState });
        }

        try
        {
            var book = await _bookService.UpdateBook(id, dto);
            return Ok(book);
        }
        catch (DataNotFoundException e)
        {
            return NotFound(new {message = e.Message});
        }
        
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Admin")]
    public async Task<ActionResult> DeleteBook(int id)
    {
        try
        {
            await _bookService.DeleteBook(id);
            return NoContent();
        }
        catch (Exception e)
        {
            return NotFound(new { message = e.Message });
        }
    }
}
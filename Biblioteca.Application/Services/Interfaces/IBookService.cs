using Biblioteca.Application.DTOs;
using Biblioteca.Application.DTOs.User;

namespace Biblioteca.Application.Services.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task<BookDto> GetBookById(int id);
    Task<BookDto> CreateBook(BookDto bookDto);
    Task<BookDto> UpdateBook(int id, BookDto bookDto);
    Task<bool> DeleteBook(int id);
}
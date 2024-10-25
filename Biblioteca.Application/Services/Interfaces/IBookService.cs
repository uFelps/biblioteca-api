using Biblioteca.Application.DTOs;
using Biblioteca.Application.DTOs.User;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.Services.Interfaces;

public interface IBookService
{
    Task<List<BookDto>> GetAllBooksAsync();
    Task<Book> GetBookById(int id);
    Task<BookDto> GetBookDtoById(int id);
    Task<BookDto> CreateBook(BookDto bookDto);
    Task<BookDto> UpdateBook(int id, BookDto bookDto);
    Task<bool> DeleteBook(int id);
}
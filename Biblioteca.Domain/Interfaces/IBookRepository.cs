using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;

public interface IBookRepository
{
    Task<List<Book>> GetAllBooksAsync();
    Task<Book?> GetBookById(int id);
    Task<Book> CreateBook(Book book);
    Task<Book> UpdateBook(Book book);
    void DeleteBook(Book book);
}
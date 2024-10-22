using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data.Repositories;

public class BookRepository : IBookRepository
{
    private readonly DataContext _dbContext;

    public BookRepository(DataContext context)
    {
        _dbContext = context;
    }

    public async Task<List<Book>> GetAllBooksAsync()
    {
        return await _dbContext
            .Books
            .AsTracking()
            .ToListAsync();
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _dbContext
            .Books
            .AsTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Book> CreateBook(Book book)
    {
         _dbContext.Books.Add(book);
         await _dbContext.SaveChangesAsync();
         return book;
    }

    public async Task<Book> UpdateBook(Book book)
    {
        _dbContext.Books.Update(book);
        await _dbContext.SaveChangesAsync();
        return book;
    }

    public async void DeleteBook(Book book)
    {
        _dbContext.Books.Remove(book);
        await _dbContext.SaveChangesAsync();
    }
}
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infra.Data.Repositories;

public class BookReservationRepository : IBookReservationRepository
{

    private readonly DataContext _dbContext;

    public BookReservationRepository(DataContext context)
    {
        _dbContext = context;
    }
    
    public async Task<BookReservation> CreateReservation(BookReservation bookReservation)
    {
        _dbContext.BookReservations.Add(bookReservation);
        await _dbContext.SaveChangesAsync();
        return bookReservation;
    }

    public async Task<List<BookReservation>> GetAllReservations()
    {
         var reservations = await _dbContext
             .BookReservations
             .Include(x => x.Book)
             .Include(x => x.Customer)
             .AsNoTracking()
             .ToListAsync();

         return reservations;
    }

    public async Task<List<BookReservation>> GetReservationsByUserId(int id)
    {
        var reservations = await _dbContext
            .BookReservations
            .Include(x => x.Customer)
            .Include(x => x.Book)
            .AsNoTracking()
            .Where(x => x.CustomerId == id)
            .ToListAsync();

        return reservations;
    }

    public async Task<BookReservation?> GetReservationById(int id)
    {
        return await _dbContext
            .BookReservations
            .Include(x => x.Customer)
            .Include(x => x.Book)
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<BookReservation> UpdateReservation(BookReservation bookReservation)
    {
        _dbContext.BookReservations.Update(bookReservation);
        await _dbContext.SaveChangesAsync();
        return bookReservation;
    }
}
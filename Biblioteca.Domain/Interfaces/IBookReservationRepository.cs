using Biblioteca.Domain.Entities;

namespace Biblioteca.Domain.Interfaces;

public interface IBookReservationRepository
{
    Task<BookReservation> CreateReservation(BookReservation bookReservation);
    Task<List<BookReservation>> GetAllReservations();
    Task<List<BookReservation>> GetReservationsByUserId(int id);
    Task<BookReservation?> GetReservationById(int id);
    Task<BookReservation> UpdateReservation(BookReservation bookReservation);
}
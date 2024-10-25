using Biblioteca.Application.DTOs;

namespace Biblioteca.Application.Services.Interfaces;

public interface IBookReservationService
{
    Task<ReservationDto> CreateNewReservation(int idBook, string token);
    Task<List<ReservationDto>> GetAllReservations();
    Task<List<ReservationDto>> GetReservationsByUserId(int id);
    Task<List<ReservationDto>> GetReservationsByUserToken(string token);
    Task<ReservationDto> CloseReservation(int id);
}
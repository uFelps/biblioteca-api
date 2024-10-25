using Biblioteca.Application.DTOs;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Security.Interfaces;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services.Implementations;

public class BookReservationService : IBookReservationService
{
    private readonly IBookService _bookService;
    private readonly ITokenService _tokenService;
    private readonly IBookReservationRepository _repository;
    private readonly IUserService _userService;

    public BookReservationService(IBookService bookService, ITokenService tokenService,
        IBookReservationRepository repository, IUserService userService)
    {
        _bookService = bookService;
        _tokenService = tokenService;
        _repository = repository;
        _userService = userService;
    }

    public async Task<ReservationDto> CreateNewReservation(int idBook, string token)
    {
        var idUser = _tokenService.GetIdFromUser(token);
        var user = await _userService.GetUserByIdAsync(idUser);
        var book = await _bookService.GetBookById(idBook);

        var reservation = new BookReservation();
        reservation.BookId = book.Id;
        reservation.CustomerId = user.Id;

        reservation.ReservedOn = DateTime.Now;
        reservation.ExpiresOn = (DateTime.Now).AddMonths(3);
        reservation.Status = ReservationStatus.Open;

        var newReservation = await _repository.CreateReservation(reservation);
        newReservation.Customer = user;
        newReservation.Book = book;

        return new ReservationDto(newReservation);
    }

    public async Task<List<ReservationDto>> GetAllReservations()
    {
        var reservations = await _repository.GetAllReservations();

        var reservationsDto = reservations
            .Select(x => new ReservationDto(x)).ToList();

        return reservationsDto;
    }

    public async Task<List<ReservationDto>> GetReservationsByUserId(int id)
    {
        var reservations = await _repository.GetReservationsByUserId(id);

        var reservationsDto = reservations.Select(x => new ReservationDto(x)).ToList();

        return reservationsDto;
    }

    public async Task<List<ReservationDto>> GetReservationsByUserToken(string token)
    {
        var idUser = _tokenService.GetIdFromUser(token);

        var reservations = await _repository.GetReservationsByUserId(idUser);

        var reservationsDto = reservations.Select(x => new ReservationDto(x)).ToList();

        return reservationsDto;
    }

    public async Task<ReservationDto> CloseReservation(int id)
    {
        var reservation = await _repository.GetReservationById(id);

        if (reservation == null)
        {
            throw new DataNotFoundException($"Reservation not found. ID={id}");
        }

        reservation.Status = ReservationStatus.Closed;

        var reservationUpdeted = await _repository.UpdateReservation(reservation);

        return new ReservationDto(reservationUpdeted);
    }
}
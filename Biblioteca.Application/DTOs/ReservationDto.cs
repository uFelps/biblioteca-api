using Biblioteca.Application.DTOs.User;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;

namespace Biblioteca.Application.DTOs;

public class ReservationDto
{
    public ReservationDto()
    {
        
    }

    public ReservationDto(int id, BookDto book, UserOutputDto customer, DateTime reservedOn, DateTime expiresOn, ReservationStatus status)
    {
        Id = id;
        Book = book;
        Customer = customer;
        ReservedOn = reservedOn;
        ExpiresOn = expiresOn;
        Status = status.ToString();
    }

    public ReservationDto(BookReservation newReservation)
    {
        Id = newReservation.Id;
        Book = new BookDto(newReservation.Book);
        Customer = new UserOutputDto(newReservation.Customer);
        ReservedOn = newReservation.ReservedOn;
        ExpiresOn = newReservation.ExpiresOn;
        Status = newReservation.Status.ToString();
    }

    public int Id { get; set; }
    public DateTime ReservedOn { get; set; }
    public DateTime ExpiresOn { get; set; }
    public string Status { get; set; }
    public BookDto? Book { get; set; }
    public UserOutputDto? Customer { get; set; }
}
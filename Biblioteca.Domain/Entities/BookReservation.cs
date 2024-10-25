using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Biblioteca.Domain.Enuns;

namespace Biblioteca.Domain.Entities;

public class BookReservation
{
    public BookReservation()
    {
        
    }

    public BookReservation(int id, Book book, User customer, DateTime reservedOn, DateTime expiresOn, ReservationStatus status)
    {
        Id = id;
        Book = book;
        Customer = customer;
        ReservedOn = reservedOn;
        ExpiresOn = expiresOn;
        Status = status;
    }

    [Key]
    public int Id { get; set; }
    public DateTime ReservedOn { get; set; }
    public DateTime ExpiresOn { get; set; }
    public ReservationStatus Status { get; set; }
    public int BookId { get; set; }
    public Book? Book { get; set; }
    public int CustomerId { get; set; }
    public User? Customer { get; set; }
    
}
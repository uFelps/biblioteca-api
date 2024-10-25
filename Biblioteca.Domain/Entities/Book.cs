using System.ComponentModel.DataAnnotations;

namespace Biblioteca.Domain.Entities;

public class Book
{
    public Book()
    {
    }

    public Book(int id, string title, string author, int pages, DateTime released)
    {
        Id = id;
        Title = title;
        Author = author;
        Pages = pages;
        Released = released;
    }

    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public int Pages { get; set; }
    public DateTime Released { get; set; }
    public List<BookReservation> Reservations { get; set; }
    
    
}
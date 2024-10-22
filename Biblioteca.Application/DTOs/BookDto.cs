using System.ComponentModel.DataAnnotations;
using Biblioteca.Domain.Entities;

namespace Biblioteca.Application.DTOs;

public class BookDto
{
    public BookDto()
    {
        
    }

    public BookDto(int? id, string title, string author, int pages, DateTime released)
    {
        Id = id;
        Title = title;
        Author = author;
        Pages = pages;
        Released = released;
    }

    public BookDto(Book book)
    {
        Id = book.Id;
        Title = book.Title;
        Author = book.Author;
        Pages = book.Pages;
        Released = book.Released;
    }

    public int? Id { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string Title { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public string Author { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public int Pages { get; set; }
    
    [Required(ErrorMessage = "This field is required")]
    public DateTime Released { get; set; }
    
    
}
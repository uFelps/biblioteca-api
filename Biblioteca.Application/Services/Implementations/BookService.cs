using Biblioteca.Application.DTOs;
using Biblioteca.Application.DTOs.User;
using Biblioteca.Application.Exceptions;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;

namespace Biblioteca.Application.Services.Implementations;

public class BookService : IBookService
{

    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }
    
    
    public async Task<List<BookDto>> GetAllBooksAsync()
    {
        var books = await _repository.GetAllBooksAsync();

        var booksDto = books.Select(x => new BookDto(x)).ToList();

        return booksDto;
    }

    public async Task<Book> GetBookById(int id)
    {
        var book = await _repository.GetBookById(id);

        if (book == null)
        {
            throw new DataNotFoundException($"Book not found. ID={id}");
        }

        return book;
    }

    public async Task<BookDto> GetBookDtoById(int id)
    {
        var book = await _repository.GetBookById(id);

        if (book == null)
        {
            throw new DataNotFoundException($"Book not found. ID={id}");
        }

        return new BookDto(book);
    }

    public async Task<BookDto> CreateBook(BookDto bookDto)
    {
        var book = new Book();
        book.Title = bookDto.Title;
        book.Author = bookDto.Author;
        book.Pages = bookDto.Pages;
        book.Released = bookDto.Released;
        
        var newbook = await _repository.CreateBook(book);

        return new BookDto(newbook);
    }

    public async Task<BookDto> UpdateBook(int id, BookDto bookDto)
    {
        var book = await _repository.GetBookById(id);

        if (book == null)
        {
            throw new DataNotFoundException($"Book not found. ID={id}");
        }

        book.Title = bookDto.Title;
        book.Author = bookDto.Author;
        book.Pages = bookDto.Pages;
        book.Released = bookDto.Released;

        var updatedbook = await _repository.UpdateBook(book);

        return new BookDto(updatedbook);
    }

    public async Task<bool> DeleteBook(int id)
    {
        var book = await _repository.GetBookById(id);

        if (book == null)
        {
            throw new DataNotFoundException($"Book not found. ID={id}");
        }
        
        _repository.DeleteBook(book);

        return true;
    }
}
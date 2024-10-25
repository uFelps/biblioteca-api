using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Enuns;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
namespace Biblioteca.Infra.Data.Context;


public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookReservation> BookReservations { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // configures one-to-many relationship
        modelBuilder.Entity<BookReservation>()
            .HasOne(br => br.Customer)
            .WithMany(cus => cus.Reservations)
            .HasForeignKey(br => br.CustomerId);

        modelBuilder.Entity<BookReservation>()
            .HasOne(br => br.Book)
            .WithMany(book => book.Reservations)
            .HasForeignKey(br => br.BookId);

    }
}

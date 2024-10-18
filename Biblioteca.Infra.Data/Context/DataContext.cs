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


}
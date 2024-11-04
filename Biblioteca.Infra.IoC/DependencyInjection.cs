using Biblioteca.Application.Security.Implementations;
using Biblioteca.Application.Security.Interfaces;
using Biblioteca.Application.Services.Implementations;
using Biblioteca.Application.Services.Interfaces;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infra.Data.Context;
using Biblioteca.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Biblioteca.Infra.IoC;

public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        
        services.AddDbContext<DataContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("ConnectionString")));


        services.AddScoped<DbContext, DataContext>();
        
        


        //repositories
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IBookRepository, BookRepository>();
        services.AddScoped<IBookReservationRepository, BookReservationRepository>();

        //services
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IPasswordEncoder, PasswordEncoder>();
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IBookReservationService, BookReservationService>();
    }
}
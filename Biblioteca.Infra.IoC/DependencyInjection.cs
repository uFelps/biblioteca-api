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
        //database
        services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("Database"));
        services.AddScoped<DbContext, DataContext>();
        
        //repositories
        services.AddScoped<IUserRepository, UserRepository>();
        
        //services
        services.AddScoped<IUserService, UserService>();
    }
    
}
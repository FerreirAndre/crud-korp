using Library.Application.Contracts.Persistence;
using Library.Persistence.DatabaseContext;
using Library.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<LibraryDatabaseContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("LibraryDatabaseConnectionString"));
        });

        services.AddScoped<IBookRepository, BookRepository>();
        
        return services;
    }
}
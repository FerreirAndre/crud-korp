using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application;

public static class ApplicationServiceRegistration
{
    public static IServiceCollection AddApplicationSErvices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
        return services;
    }
}
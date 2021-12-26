using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Generic.Categories;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
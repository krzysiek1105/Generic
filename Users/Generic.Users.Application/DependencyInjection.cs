using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Generic.Users.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModuleApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
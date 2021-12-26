using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Generic.Users.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModuleApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
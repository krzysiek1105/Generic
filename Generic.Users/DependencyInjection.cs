using Generic.Users.Domain;
using Generic.Users.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Generic.Users;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModule(this IServiceCollection services)
    {
        services.AddTransient<IEmailMessageBuilder, EmailMessageBuilder>();
        services.AddSingleton<IUserRepository, UserRepository>();

        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
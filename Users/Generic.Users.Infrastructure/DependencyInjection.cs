using Generic.Users.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Generic.Users.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddUsersModuleInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<IEmailMessageBuilder, EmailMessageBuilder>();
        services.AddSingleton<IUserRepository, UserRepository>();

        return services;
    }
}
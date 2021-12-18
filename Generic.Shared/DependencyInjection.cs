using Generic.Shared.Domain;
using Generic.Shared.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Generic.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddTransient<IEmailSender, EmailSender>();

        return services;
    }
}
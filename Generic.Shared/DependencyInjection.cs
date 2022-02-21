using Generic.Shared.Application.PipelineBehaviors;
using Generic.Shared.Domain;
using Generic.Shared.Infrastructure;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Generic.Shared;

public static class DependencyInjection
{
    public static IServiceCollection AddSharedModule(this IServiceCollection services)
    {
        services.AddTransient<IEmailSender, EmailSender>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(TransactionPipelineBehavior<,>));

        return services;
    }
}
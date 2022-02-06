using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Generic.Categories.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddCategoriesModuleApplication(this IServiceCollection services)
    {
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
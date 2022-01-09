using Generic.Categories.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace Generic.Categories.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddCategoriesModuleInfrastructure(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        return services;
    }
}
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Generic.Categories.Domain;
using Generic.Categories.Infrastructure;

namespace Generic.Categories;

public static class DependencyInjection
{
    public static IServiceCollection AddCategoriesModule(this IServiceCollection services)
    {
        services.AddTransient<ICategoryRepository, CategoryRepository>();
        services.AddMediatR(Assembly.GetExecutingAssembly());
        return services;
    }
}
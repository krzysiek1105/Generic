using Generic.Categories.Domain;

namespace Generic.Categories.Infrastructure;

internal class CategoryRepository : ICategoryRepository
{
    private readonly Dictionary<Guid, Category> _categories;

    public CategoryRepository()
    {
        _categories = new Dictionary<Guid, Category>();
    }

    public Task<Category> Create(Category entity)
    {
        _categories.Add(entity.Id, entity);
        return Task.FromResult(entity);
    }

    public Task<Category?> Get(Guid id)
    {
        return _categories.ContainsKey(id) ? Task.FromResult<Category?>(_categories[id]) : Task.FromResult<Category?>(null);
    }

    public Task<bool> Exists(Guid id)
    {
        return Task.FromResult(_categories.ContainsKey(id));
    }

    public Task Update(Category entity)
    {
        _categories[entity.Id] = entity;
        return Task.CompletedTask;
    }

    public Task Delete(Guid id)
    {
        _categories.Remove(id);
        return Task.CompletedTask;
    }

    public Task Delete(Category entity)
    {
        _categories.Remove(entity.Id);
        return Task.CompletedTask;
    }

    public Task SaveChanges()
    {
        return Task.CompletedTask;
    }
}
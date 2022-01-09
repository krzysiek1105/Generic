using Generic.Shared.Domain;

namespace Generic.Categories.Domain;

public class Category : Entity, IAggregateRoot
{
    public Category? Parent { get; private set; }
    public string Name { get; }

    public Category(string name, Category? parent = null)
    {
        Name = name;
        Parent = parent;
    }

    public void SetParentCategory(Category parent)
    {
        Parent = parent;
    }
}
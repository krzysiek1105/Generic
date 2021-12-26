using Generic.Shared.Application;

namespace Generic.Categories.Application.Commands.CreateCategory;

public class CreateCategoryCommandResult : ICommandResult
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public Guid? ParentCategoryId { get; set; }
}
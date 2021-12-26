using MediatR;

namespace Generic.Categories.Application.Commands.CreateCategory;

public class CreateCategoryCommandRequest : IRequest<CreateCategoryCommandResult>
{
    public Guid UserId { get; set; }
    public Guid? ParentId { get; set; }
    public string Name { get; set; } = string.Empty;
}
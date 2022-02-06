using Generic.Shared.Application;

namespace Generic.Categories.Application.Commands.CreateCategory.FailureReasons;

internal class ParentCategoryDoesNotExist : ICommandFailureReason
{
    private readonly Guid _parentId;

    public ParentCategoryDoesNotExist(Guid parentId)
    {
        _parentId = parentId;
    }

    public string Description => $"Parent category '{_parentId}' does not exist";
}
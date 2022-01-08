using Generic.Categories.Domain;
using Generic.Shared.Application;
using Generic.Users.Domain;
using MediatR;

namespace Generic.Categories.Application.Commands.CreateCategory;

internal class CreateCategoryCommand : IRequestHandler<CreateCategoryCommandRequest, ICommandResult<CreateCategoryCommandResult>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;

    public CreateCategoryCommand(IUserRepository userRepository, ICategoryRepository categoryRepository)
    {
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<ICommandResult<CreateCategoryCommandResult>> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.Exists(request.UserId))
        {
            return CommandResult<CreateCategoryCommandResult>.Failure($"User {request.UserId} does not exist");
        }

        var category = new Category(request.Name);
        if (request.ParentId.HasValue)
        {
            var parentCategory = await _categoryRepository.Get(request.ParentId.Value);
            if (parentCategory == null)
            {
                return CommandResult<CreateCategoryCommandResult>.Failure($"Parent category {request.ParentId} does not exist");
            }

            category.SetParentCategory(parentCategory);
        }

        await _categoryRepository.Create(category);
        await _categoryRepository.SaveChanges();

        return CommandResult<CreateCategoryCommandResult>.Success(new CreateCategoryCommandResult
        {
            Name = category.Name,
            Id = category.Id,
            ParentCategoryId = category.Parent?.Id
        });
    }
}
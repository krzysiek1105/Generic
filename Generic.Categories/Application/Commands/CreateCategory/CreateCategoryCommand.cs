using Generic.Categories.Domain;
using Generic.Shared.Domain;
using Generic.Users.Domain;
using MediatR;

namespace Generic.Categories.Application.Commands.CreateCategory;

internal class CreateCategoryCommand : IRequestHandler<CreateCategoryCommandRequest, CreateCategoryCommandResult>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IUserRepository _userRepository;

    public CreateCategoryCommand(IUserRepository userRepository, ICategoryRepository categoryRepository)
    {
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommandRequest request, CancellationToken cancellationToken)
    {
        if (!await _userRepository.Exists(request.UserId))
        {
            throw new DomainException($"User {request.UserId} does not exist");
        }

        var category = new Category(request.Name);
        if (request.ParentId.HasValue)
        {
            var parentCategory = await _categoryRepository.Get(request.ParentId.Value);
            if (parentCategory == null)
            {
                throw new DomainException($"Parent category {request.ParentId} does not exist");
            }

            category.SetParentCategory(parentCategory);
        }

        await _categoryRepository.Create(category);
        await _categoryRepository.SaveChanges();

        return new CreateCategoryCommandResult
        {
            Id = category.Id,
            Name = category.Name,
            ParentCategoryId = category.Parent?.Id
        };
    }
}
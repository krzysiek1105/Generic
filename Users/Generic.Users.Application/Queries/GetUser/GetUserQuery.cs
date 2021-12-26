using Generic.Shared.Domain;
using Generic.Users.Domain;
using MediatR;

namespace Generic.Users.Application.Queries.GetUser;

internal class GetUserQuery : IRequestHandler<GetUserQueryRequest, GetUserQueryResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserQuery(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetUserQueryResult> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id);
        if (user == null)
        {
            throw new DomainException($"User {request.Id} does not exist");
        }

        return new GetUserQueryResult
        {
            Id = user.Id,
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value
        };
    }
}
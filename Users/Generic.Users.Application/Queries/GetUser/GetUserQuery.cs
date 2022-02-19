using Generic.Shared.Application;
using Generic.Shared.Application.FailureReasons;
using Generic.Users.Domain;

namespace Generic.Users.Application.Queries.GetUser;

internal class GetUserQuery : CommandHandlerBase<GetUserQueryRequest, GetUserQueryResult>
{
    private readonly IUserRepository _userRepository;

    public GetUserQuery(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public override async Task<ICommandResult<GetUserQueryResult>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id);
        if (user == null)
        {
            return Failure(new UserDoesNotExist(request.Id));
        }

        return Success(new GetUserQueryResult
        {
            Id = user.Id,
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value
        });
    }
}
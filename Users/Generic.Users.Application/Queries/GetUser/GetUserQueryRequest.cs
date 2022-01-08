using Generic.Shared.Application;
using MediatR;

namespace Generic.Users.Application.Queries.GetUser;

public class GetUserQueryRequest : IRequest<ICommandResult<GetUserQueryResult>>
{
    public Guid Id { get; set; }
}
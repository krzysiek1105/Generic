using MediatR;

namespace Generic.Users.Application.Queries.GetUser;

public class GetUserQueryRequest : IRequest<GetUserQueryResult>
{
    public Guid Id { get; set; }
}
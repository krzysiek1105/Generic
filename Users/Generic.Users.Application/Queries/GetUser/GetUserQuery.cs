﻿using Generic.Shared.Application;
using Generic.Shared.Application.FailureReasons;
using Generic.Users.Domain;
using MediatR;

namespace Generic.Users.Application.Queries.GetUser;

internal class GetUserQuery : IRequestHandler<GetUserQueryRequest, ICommandResult<GetUserQueryResult>>
{
    private readonly IUserRepository _userRepository;

    public GetUserQuery(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ICommandResult<GetUserQueryResult>> Handle(GetUserQueryRequest request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.Get(request.Id);
        if (user == null)
        {
            return new CommandResult<GetUserQueryResult>().AddFailureReason(new UserDoesNotExist(request.Id));
        }

        return new CommandResult<GetUserQueryResult>().SetResult(new GetUserQueryResult
        {
            Id = user.Id,
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value
        });
    }
}
using MediatR;

namespace Generic.Shared.Application;

public abstract class CommandHandlerBase<TRequest, TResult> : IRequestHandler<TRequest, ICommandResult<TResult>>
    where TRequest : IRequest<ICommandResult<TResult>>
{
    public abstract Task<ICommandResult<TResult>> Handle(TRequest request, CancellationToken cancellationToken);

    protected ICommandResult<TResult> Success(TResult result)
    {
        return new DefaultCommandResult<TResult>().SetResult(result);
    }

    protected ICommandResult<TResult> Failure(params ICommandFailureReason[] failureReasons)
    {
        var commandResult = new DefaultCommandResult<TResult>();
        foreach (var failureReason in failureReasons)
        {
            commandResult.AddFailureReason(failureReason);
        }

        return commandResult;
    }

    protected ICommandResult<TResult> CommandResult()
    {
        return new DefaultCommandResult<TResult>();
    }
}

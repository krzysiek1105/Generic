using System.Collections.ObjectModel;

namespace Generic.Shared.Application;

public class CommandResult<T> : ICommandResult<T>
{
    private readonly IList<ICommandFailureReason> _failureReasons;

    public CommandResult()
    {
        _failureReasons = new List<ICommandFailureReason>();
    }

    public CommandResult<T> SetResult(T result)
    {
        ArgumentNullException.ThrowIfNull(result);

        Result = result;
        return this;
    }

    public CommandResult<T> AddFailureReason(ICommandFailureReason failureReason)
    {
        ArgumentNullException.ThrowIfNull(failureReason);

        _failureReasons.Add(failureReason);
        return this;
    }

    public bool Successful => !_failureReasons.Any();

    public IEnumerable<ICommandFailureReason> FailureReasons => new ReadOnlyCollection<ICommandFailureReason>(_failureReasons);
    public T? Result { get; private set; }
}
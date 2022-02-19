using System.Collections.ObjectModel;

namespace Generic.Shared.Application;

internal class DefaultCommandResult<T> : ICommandResult<T>
{
    private readonly IList<ICommandFailureReason> _failureReasons;

    public DefaultCommandResult()
    {
        _failureReasons = new List<ICommandFailureReason>();
    }

    public ICommandResult<T> SetResult(T result)
    {
        ArgumentNullException.ThrowIfNull(result);

        Result = result;
        return this;
    }

    public ICommandResult<T> AddFailureReason(ICommandFailureReason failureReason)
    {
        ArgumentNullException.ThrowIfNull(failureReason);

        _failureReasons.Add(failureReason);
        return this;
    }

    public bool Successful => !_failureReasons.Any();

    public IEnumerable<ICommandFailureReason> FailureReasons => new ReadOnlyCollection<ICommandFailureReason>(_failureReasons);
    public T? Result { get; private set; }
}
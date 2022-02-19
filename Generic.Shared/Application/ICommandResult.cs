namespace Generic.Shared.Application;

public interface ICommandResult<T>
{
    bool Successful { get; }
    IEnumerable<ICommandFailureReason> FailureReasons { get; }
    T? Result { get; }

    ICommandResult<T> SetResult(T result);
    ICommandResult<T> AddFailureReason(ICommandFailureReason failureReason);
}
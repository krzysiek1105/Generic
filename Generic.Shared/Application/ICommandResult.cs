namespace Generic.Shared.Application;

public interface ICommandResult<out T>
{
    bool Successful { get; }
    IEnumerable<ICommandFailureReason> FailureReasons { get; }
    T? Result { get; }
}
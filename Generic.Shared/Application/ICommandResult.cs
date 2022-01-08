namespace Generic.Shared.Application;

public interface ICommandResult<out T>
{
    bool Successful { get; }
    IEnumerable<string> ErrorMessages { get; }
    T? Result { get; }
}
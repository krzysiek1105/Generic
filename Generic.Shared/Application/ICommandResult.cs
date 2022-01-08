namespace Generic.Shared.Application;

public interface ICommandResult<out T>
{
    bool Successful { get; }
    IDictionary<string, string> ErrorMessages { get; }
    T? Result { get; }
}
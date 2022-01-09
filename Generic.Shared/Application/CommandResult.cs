using System.Collections.ObjectModel;

namespace Generic.Shared.Application;

public class CommandResult<T> : ICommandResult<T>
{
    private readonly IDictionary<string, string> _errorMessages;

    private CommandResult()
    {
        _errorMessages = new Dictionary<string, string>();
    }

    public static CommandResult<T> Success(T result)
    {
        ArgumentNullException.ThrowIfNull(result);

        return new CommandResult<T>
        {
            Successful = true,
            Result = result
        };
    }

    public static CommandResult<T> Failure(string key, string message)
    {
        var commandResult = new CommandResult<T>
        {
            Successful = false,
            Result = default
        };

        commandResult.AddErrorMessage(key, message);

        return commandResult;
    }

    public static CommandResult<T> Failure(IDictionary<string, string> errorMessages)
    {
        var commandResult = new CommandResult<T>
        {
            Successful = false,
            Result = default
        };

        foreach (var (key, message) in errorMessages)
        {
            commandResult.AddErrorMessage(key, message);
        }

        return commandResult;
    }

    private void AddErrorMessage(string key, string message)
    {
        _errorMessages.Add(key, message);
    }

    public bool Successful { get; init; }

    public IDictionary<string, string> ErrorMessages => new ReadOnlyDictionary<string, string>(_errorMessages);
    public T? Result { get; init; }
}
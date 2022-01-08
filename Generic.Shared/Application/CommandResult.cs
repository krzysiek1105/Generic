namespace Generic.Shared.Application;

public class CommandResult<T> : ICommandResult<T>
{
    private readonly List<string> _errorMessages;

    private CommandResult()
    {
        _errorMessages = new List<string>();
    }

    public static CommandResult<T> Success(T result)
    {
        return new CommandResult<T>
        {
            Successful = true,
            Result = result
        };
    }

    public static CommandResult<T> Failure(params string[] errorMessages)
    {
        var commandResult = new CommandResult<T>
        {
            Successful = false,
            Result = default
        };

        foreach (var errorMessage in errorMessages)
        {
            commandResult.AddErrorMessage(errorMessage);
        }

        return commandResult;
    }

    public static CommandResult<T> Failure(IEnumerable<string> errorMessages)
    {
        var commandResult = new CommandResult<T>
        {
            Successful = false,
            Result = default
        };

        foreach (var errorMessage in errorMessages)
        {
            commandResult.AddErrorMessage(errorMessage);
        }

        return commandResult;
    }

    public void AddErrorMessage(string message)
    {
        _errorMessages.Add(message);
    }

    public bool Successful { get; init; }

    public IEnumerable<string> ErrorMessages => _errorMessages.AsReadOnly();
    public T? Result { get; init; }
}
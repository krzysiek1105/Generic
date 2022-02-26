namespace Generic.Shared.Application.FailureReasons;

public class DomainRuleBroken : ICommandFailureReason
{
    public string Description { get; }

    public DomainRuleBroken(string reason)
    {
        Description = reason;
    }
}
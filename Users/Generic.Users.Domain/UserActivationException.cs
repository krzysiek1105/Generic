using System.Runtime.Serialization;
using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public class UserActivationException : DomainException
{
    public UserActivationException()
    {
    }

    public UserActivationException(string message) : base(message)
    {
    }

    public UserActivationException(string message, Exception inner) : base(message, inner)
    {
    }

    protected UserActivationException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
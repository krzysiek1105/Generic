using Generic.Shared.Domain;

namespace Generic.Users.Domain;

internal class User : Entity, IAggregateRoot
{
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Email Email { get; }
    public Password Password { get; }

    internal User(FirstName firstName, LastName lastName, Email email, Password password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;
    }
}
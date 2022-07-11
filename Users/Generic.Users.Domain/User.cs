using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public class User : Entity, IAggregateRoot
{
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public Email Email { get; }
    public Password Password { get; }
    public bool IsActivated { get; private set; }
    public Guid? ActivationToken { get; private set; }

    public User(FirstName firstName, LastName lastName, Email email, Password password)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        Password = password;

        IsActivated = false;
        ActivationToken = Guid.NewGuid();
    }

    public void Activate(Guid activationToken)
    {
        if (IsActivated)
        {
            throw new UserActivationException("User has already been activated");
        }

        if (activationToken != ActivationToken!.Value)
        {
            throw new UserActivationException("Invalid activation token");
        }

        IsActivated = true;
        ActivationToken = null;
    }
}
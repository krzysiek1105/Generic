using Generic.Shared.Domain;
using Generic.Users.Domain;

namespace Generic.Users.Tests
{
    internal static class Users
    {
        public static User JohnDoe(bool isActivated = true)
        {
            var user = new User(new FirstName("John"), new LastName("Doe"), new Email("john.doe@example.com"), new Password("password"));
            if (isActivated)
            {
                user.Activate(user.ActivationToken!.Value);
            }

            return user;
        }
    }
}

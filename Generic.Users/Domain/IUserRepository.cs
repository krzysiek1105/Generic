using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public interface IUserRepository : ICrudRepository<User>
{
    bool IsEmailUnused(Email email);
}
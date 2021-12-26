using Generic.Shared.Domain;

namespace Generic.Users.Domain;

public interface IUserRepository : ICrudRepository<User>
{
    Task<bool> IsEmailUnused(Email email);
}
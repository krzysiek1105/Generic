using Generic.Shared.Domain;

namespace Generic.Users.Domain;

internal interface IUserRepository : ICrudRepository<User>
{
    bool IsEmailUnused(Email email);
}
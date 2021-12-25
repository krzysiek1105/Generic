using Generic.Shared.Domain;

namespace Generic.Users.Domain;

internal interface IUserRepository : ICrudRepository<User>
{
    Task<bool> IsEmailUnused(Email email);
}
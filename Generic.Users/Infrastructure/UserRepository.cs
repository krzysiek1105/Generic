using Generic.Shared.Domain;
using Generic.Users.Domain;

namespace Generic.Users.Infrastructure
{
    internal class UserRepository : IUserRepository
    {
        private readonly Dictionary<Guid, User> _users;

        public UserRepository()
        {
            _users = new Dictionary<Guid, User>();
        }

        public Task<User> Create(User entity)
        {
            _users.Add(entity.Id, entity);
            return Task.FromResult(entity);
        }

        public Task<User?> Get(Guid id)
        {
            return _users.ContainsKey(id) ? Task.FromResult<User?>(_users[id]) : Task.FromResult<User?>(null);
        }

        public Task<bool> Exists(Guid id)
        {
            return Task.FromResult(_users.ContainsKey(id));
        }

        public Task Update(User entity)
        {
            _users[entity.Id] = entity;
            return Task.CompletedTask;
        }

        public Task Delete(Guid id)
        {
            _users.Remove(id);
            return Task.CompletedTask;
        }

        public Task Delete(User entity)
        {
            _users.Remove(entity.Id);
            return Task.CompletedTask;
        }

        public Task SaveChanges()
        {
            return Task.CompletedTask;
        }

        public Task<bool> IsEmailUnused(Email email)
        {
            return Task.FromResult(_users.Values.All(user => user.Email != email));
        }
    }
}

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

        public User Create(User entity)
        {
            _users.Add(entity.Id, entity);
            return entity;
        }

        public User Get(Guid id)
        {
            return _users[id];
        }

        public void Update(User entity)
        {
            _users[entity.Id] = entity;
        }

        public void Delete(Guid id)
        {
            _users.Remove(id);
        }

        public void Delete(User entity)
        {
            _users.Remove(entity.Id);
        }

        public void SaveChanges()
        {
        }

        public bool IsEmailUnused(Email email)
        {
            return _users.Values.All(user => user.Email != email);
        }
    }
}

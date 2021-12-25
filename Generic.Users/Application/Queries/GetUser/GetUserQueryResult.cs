using Generic.Shared.Application;

namespace Generic.Users.Application.Queries.GetUser
{
    public class GetUserQueryResult : ICommandResult
    {
        public Guid Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
using Generic.Shared.Domain;
using Generic.Users.Domain;
using MediatR;
using IEmailSender = Generic.Shared.Domain.IEmailSender;

namespace Generic.Users.Application.Commands.CreateUser;

public class CreateUserCommand : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResult>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailSender _emailSender;
    private readonly IEmailMessageBuilder _emailMessageBuilder;

    public CreateUserCommand(IUserRepository userRepository, IEmailSender emailSender, IEmailMessageBuilder emailMessageBuilder)
    {
        _userRepository = userRepository;
        _emailSender = emailSender;
        _emailMessageBuilder = emailMessageBuilder;
    }

    public Task<CreateUserCommandResult> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
    {
        var firstName = new FirstName(request.FirstName);
        var lastName = new LastName(request.LastName);
        var email = new Email(request.Email);
        var password = new Password(request.Password);

        if (!_userRepository.IsEmailUnused(email))
        {
            throw new DomainException("Email is already in use");
        }

        var user = new User(firstName, lastName, email, password);

        _userRepository.Create(user);
        _userRepository.SaveChanges();

        var welcomeMessage = _emailMessageBuilder.CreateWelcomeMessage(user);
        _emailSender.Send(welcomeMessage);

        return Task.FromResult(new CreateUserCommandResult
        {
            Id = user.Id,
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value
        });
    }
}
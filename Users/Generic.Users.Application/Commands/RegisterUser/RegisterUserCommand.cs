using Generic.Shared.Application;
using Generic.Shared.Domain;
using Generic.Users.Application.Commands.RegisterUser.FailureReasons;
using Generic.Users.Domain;
using MediatR;
using IEmailSender = Generic.Shared.Domain.IEmailSender;

namespace Generic.Users.Application.Commands.RegisterUser;

internal class RegisterUserCommand : IRequestHandler<RegisterUserCommandRequest, ICommandResult<RegisterUserCommandResult>>
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailSender _emailSender;
    private readonly IEmailMessageBuilder _emailMessageBuilder;

    public RegisterUserCommand(IUserRepository userRepository, IEmailSender emailSender, IEmailMessageBuilder emailMessageBuilder)
    {
        _userRepository = userRepository;
        _emailSender = emailSender;
        _emailMessageBuilder = emailMessageBuilder;
    }

    public async Task<ICommandResult<RegisterUserCommandResult>> Handle(RegisterUserCommandRequest request, CancellationToken cancellationToken)
    {
        var firstName = new FirstName(request.FirstName);
        var lastName = new LastName(request.LastName);
        var email = new Email(request.Email);
        var password = new Password(request.Password);

        if (!await _userRepository.IsEmailUnused(email))
        {
            return new CommandResult<RegisterUserCommandResult>().AddFailureReason(new EmailAlreadyUsed(email.Value));
        }

        var user = new User(firstName, lastName, email, password);

        await _userRepository.Create(user);
        await _userRepository.SaveChanges();

        var welcomeMessage = _emailMessageBuilder.CreateWelcomeMessage(user);
        _emailSender.Send(welcomeMessage);

        return new CommandResult<RegisterUserCommandResult>().SetResult(new RegisterUserCommandResult
        {
            Id = user.Id,
            Email = user.Email.Value,
            FirstName = user.FirstName.Value,
            LastName = user.LastName.Value
        });
    }
}
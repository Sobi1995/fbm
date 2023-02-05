
using Application.Common.Models;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
namespace Application.Commands.Auth;

public record RegisterUserCommand : IRequest<IServiceResult<Guid>>
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,IServiceResult<Guid>>
{
    private readonly IIdentityService _identityService;
 

    public RegisterUserCommandHandler(IIdentityService identityService) =>
        (_identityService) = (identityService);

    public async Task<IServiceResult<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        var checkUserExist =await _identityService.CheckIfUserExist(request.UserName);
        if (checkUserExist)
            return new ServiceResult<Guid>().Failure("This username is already taken");
        var createResult = await _identityService.CreateUserAsync(request.UserName, request.Password);
        //_forbid.False(createResult.Succeeded, RegisterException.Instance);
        return new ServiceResult<Guid>().Ok(createResult.UserId);
    }
}
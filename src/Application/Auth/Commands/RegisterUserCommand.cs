
using Application.Common.Models;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;
namespace Application.Commands.Auth;

public record RegisterUserCommand : IRequest<IResponse<Guid>>
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;
    public string ConfirmPassword { get; set; } = default!;
}

public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand,IResponse<Guid>>
{
    private readonly IIdentityService _identityService;
 

    public RegisterUserCommandHandler(IIdentityService identityService) =>
        (_identityService) = (identityService);

    public async Task<IResponse<Guid>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
 
        var createResult = await _identityService.CreateUserAsync(request.UserName, request.Password);
        //_forbid.False(createResult.Succeeded, RegisterException.Instance);
        return new Response<Guid>(createResult.UserId,true);
    }
}
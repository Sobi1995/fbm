
using System.Security.Principal;
using Application.Common.Models;
using Application.Common.Wrappers;
using CleanArchitecture.Application.Auth.Dto;
using CleanArchitecture.Application.Common.Interfaces;
 
using MediatR;
 

namespace Application.Commands.Auth;

public record RegisterUserCommand(RegisterUserRequest RegisterUserRequest) : IRequestWrapper<Unit>;

public class RegisterUserCommandHandler : IHandlerWrapper<RegisterUserCommand,Unit>
{
    private readonly IIdentityService _identityService;
 

    public RegisterUserCommandHandler(IIdentityService identityService) =>
        (_identityService) = (identityService);

    public async Task<IResponse<Unit>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
 
        var createResult = await _identityService.CreateUserAsync(request.RegisterUserRequest.UserName, request.RegisterUserRequest.Password);
        //_forbid.False(createResult.Succeeded, RegisterException.Instance);
        return Response.Success(Unit.Value);
    }
}
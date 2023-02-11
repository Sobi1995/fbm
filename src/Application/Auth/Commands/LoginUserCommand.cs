using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;
using CleanArchitecture.Application.Auth.Dto;
using CleanArchitecture.Application.Common.Interfaces;
using MediatR;

namespace CleanArchitecture.Application.Auth.Commands;
public record LoginUserCommand  : IRequest<IResponse<AuthenticateResponse>>
{
    public string UserName { get; set; } = default!;
    public string Password { get; set; } = default!;

}

public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, IResponse<AuthenticateResponse>>
{
 
    private readonly IIdentityService _identityService;

    public LoginUserCommandHandler(IIdentityService identityService)
    {
        _identityService = identityService;
    }

    public async Task<IResponse<AuthenticateResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
        var checkUserExist = await _identityService.CheckIfUserExist(request.UserName);

        if (checkUserExist)
            return new Response<AuthenticateResponse>(HttpStatusCode.NotFound).Failure("Notfound the username");


        var signInResult =
         await _identityService.PasswordSignInAsync(user, request.LoginUserRequest.Password, false, false);
        _forbid.False(signInResult.Succeeded, SignInException.Instance);
        return Response.Success(await _authenticateService.Authenticate(user, cancellationToken));


        return null;
    }
}

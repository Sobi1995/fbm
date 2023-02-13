using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Models;
using CleanArchitecture.Application.Auth.Dto;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Interfaces.Auth;
using CleanArchitecture.Application.Common.Models;
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
    private readonly IAuthenticateService _authenticateService;
    public LoginUserCommandHandler(IIdentityService identityService,
                                   IAuthenticateService authenticateService)
    {
        _identityService = identityService;
        _authenticateService = authenticateService;
    }

    public async Task<IResponse<AuthenticateResponse>> Handle(LoginUserCommand request, CancellationToken cancellationToken)
    {
       


        var signInResult =
         await _identityService.PasswordSignInAsync(request.UserName,request.Password);



      var result=  await _authenticateService.Authenticate(new UserClaimsModel() { Id = Guid.NewGuid(), UserName = request.UserName }, cancellationToken);
        return null;
    }
}

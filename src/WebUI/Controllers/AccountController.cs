using System.Threading;
using Application.Commands.Auth;
using Application.Common.Models;
using CleanArchitecture.Application.Auth.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CleanArchitecture.WebUI.Controllers;
public class AccountController :  ApiControllerBase
{

    [HttpPost]
    public async Task<ActionResult> Register(RegisterUserCommand registerUserCommand, CancellationToken cancellationToken)
    {
       var result= await Mediator.Send(registerUserCommand, cancellationToken);
        return Ok( result);
     
    }

    [HttpGet]
    public async Task<ActionResult> Login(LoginUserCommand loginUserCommand, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(loginUserCommand, cancellationToken);
        return Ok(result);

    }

}

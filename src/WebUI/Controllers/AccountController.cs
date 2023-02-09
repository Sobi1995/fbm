using System.Threading;
using Application.Commands.Auth;
using Application.Common.Models;
using Azure;
using CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using CleanArchitecture.WebUI.Controllers;
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
 
}

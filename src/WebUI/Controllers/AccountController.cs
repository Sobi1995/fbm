using System.Threading;
using Application.Commands.Auth;
using Application.Common.Models;
using Azure;
using CleanArchitecture.Application.Auth.Dto;
using CleanArchitecture.Application.WeatherForecasts.Queries.GetWeatherForecasts;
using CleanArchitecture.WebUI.Controllers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CleanArchitecture.WebUI.Controllers;
public class AccountController :  ApiControllerBase
{

    [HttpPost]
    public async Task<IResponse<Unit>> Register(RegisterUserRequest registerUserRequest, CancellationToken cancellationToken)
    {
       var result= await Mediator.Send(new RegisterUserCommand(registerUserRequest), cancellationToken);
        return result;
     
    }
    [HttpGet]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        return await Mediator.Send(new GetWeatherForecastsQuery());
    }
}

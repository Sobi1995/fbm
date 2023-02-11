﻿using System.Collections.Generic;
using System.Security.Claims;
using CleanArchitecture.Application.Common.Interfaces.Auth;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Setting;
 

namespace Infrastructure.Services;

public class AccessTokenService : IAccessTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public AccessTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings) =>
        (_tokenGenerator, _jwtSettings) = (tokenGenerator, jwtSettings);

    public string Generate(UserClaimsModel user)
    {
        List<Claim> claims = new()
        {
            new Claim("id", user.Id.ToString()),
            //new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };
        return _tokenGenerator.Generate(_jwtSettings.AccessTokenSecret, _jwtSettings.Issuer, _jwtSettings.Audience,
            _jwtSettings.AccessTokenExpirationMinutes, claims);
    }
}
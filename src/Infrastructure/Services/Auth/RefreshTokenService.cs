
using CleanArchitecture.Application.Common.Interfaces.Auth;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Setting;


namespace Infrastructure.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
    private readonly JwtSettings _jwtSettings;

    public RefreshTokenService(ITokenGenerator tokenGenerator, JwtSettings jwtSettings) =>
        (_tokenGenerator, _jwtSettings) = (tokenGenerator, jwtSettings);

    public string Generate(UserClaimsModel user) => _tokenGenerator.Generate(_jwtSettings.RefreshTokenSecret,
        _jwtSettings.Issuer, _jwtSettings.Audience,
        _jwtSettings.RefreshTokenExpirationMinutes);
}

using CleanArchitecture.Application.Common.Interfaces.Auth;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Application.Common.Setting;


namespace Infrastructure.Services;

public class RefreshTokenService : IRefreshTokenService
{
    private readonly ITokenGenerator _tokenGenerator;
 

    public RefreshTokenService(ITokenGenerator tokenGenerator ) =>
        (_tokenGenerator) = (tokenGenerator);

    public string Generate(UserClaimsModel user) => _tokenGenerator.Generate("_jwtSettings.RefreshTokenSecret",
        "_jwtSettings.Issuer", "_jwtSettings.Audience",
        5);
}
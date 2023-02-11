using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Auth.Dto;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Interfaces.Auth;
using CleanArchitecture.Application.Common.Models;
using CleanArchitecture.Domain.Entities;

namespace Infrastructure.Services;

public class AuthenticateService : IAuthenticateService
{
    private readonly IAccessTokenService _accessTokenService;
    private readonly IRefreshTokenService _refreshTokenService;
    private readonly IApplicationDbContext _context;
    public AuthenticateService(IAccessTokenService accessTokenService, IRefreshTokenService refreshTokenService, IApplicationDbContext context)
    {
        _accessTokenService = accessTokenService;
        _refreshTokenService = refreshTokenService;
        _context = context;
    }

    public async Task<AuthenticateResponse> Authenticate(UserClaimsModel user,CancellationToken cancellationToken)
    {
        var refreshToken = _refreshTokenService.Generate(user);
        await _context.RefreshTokens.AddAsync(new RefreshToken(user.Id, refreshToken), cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return new AuthenticateResponse
        {
            AccessToken = _accessTokenService.Generate(user),
            RefreshToken = refreshToken
        };
    }
}
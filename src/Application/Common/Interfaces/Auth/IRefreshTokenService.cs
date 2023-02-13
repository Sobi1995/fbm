

using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Interfaces.Auth;


public interface IRefreshTokenService { string Generate(UserClaimsModel user); }
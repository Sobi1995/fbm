

using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Interfaces.Auth;

public interface IAccessTokenService { string Generate(UserClaimsModel user); }
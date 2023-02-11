

namespace CleanArchitecture.Application.Common.Interfaces.Auth;


public interface IRefreshTokenValidator
{
 
    bool Validate(string refreshToken);
}
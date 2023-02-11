using System.Threading;
using System.Threading.Tasks;
using CleanArchitecture.Application.Auth.Dto;
using CleanArchitecture.Application.Common.Models;

namespace CleanArchitecture.Application.Common.Interfaces.Auth;



public interface IAuthenticateService
{
    
    Task<AuthenticateResponse> Authenticate(UserClaimsModel user,CancellationToken cancellationToken);
}
 
using System.Security.Claims;
 

namespace CleanArchitecture.Application.Common.Interfaces.Auth;


public interface ITokenGenerator
{
   
    string Generate(string secretKey, string issuer, string audience, double expires,
        IEnumerable<Claim> claims = null);
}
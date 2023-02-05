using System.Security.Claims;

using CleanArchitecture.Application.Common.Interfaces;

namespace WebUI.Model.Services;

public class CurrentUserService : ICurrentUserService
{

    private readonly IHttpContextAccessor _httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? UserId
    {
        get
        {
            if (_httpContextAccessor.HttpContext?.User?.Identity.IsAuthenticated != true) return null;
            if (!Guid.TryParse(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier), out Guid userId))
            {
                throw new Exception("User Id is not a valid Guid");
            }
            return userId;
        }
    }

    public bool IsAuthenticated => _httpContextAccessor.HttpContext?.User?.Identity.IsAuthenticated ?? false;
}




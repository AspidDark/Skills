using System.Security.Claims;

namespace Skills.Extensions;

public static class GeneralExtensions
{
    public static Guid? GetUserId(this HttpContext httpContext)
    {
        if (httpContext.User is not null)
        {
            var userId = httpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (Guid.TryParse(userId, out Guid id))
            {
                return id;
            }
        }
        return null;
    }

    public static Guid GetUserId(this ClaimsPrincipal claimsPrincipal)
    {
        string userId = claimsPrincipal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value;
        return Guid.Parse(userId);
    }
}
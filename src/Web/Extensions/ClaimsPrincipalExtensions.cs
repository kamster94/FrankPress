using System.Linq;
using System.Security.Claims;

namespace FrankPress.Web.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string GetEmail(this ClaimsPrincipal principal) =>
            principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;

        public static string GetName(this ClaimsPrincipal principal) =>
            principal.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Name)?.Value;
        
        public static string GetLastName(this ClaimsPrincipal principal) =>
            principal.Claims.FirstOrDefault(c => c.Type == "lastname")?.Value;

        public static string GetIdentityProvider(this ClaimsPrincipal principal) =>
            principal.Claims.FirstOrDefault(c => c.Type == "provider")?.Value;
    }
}

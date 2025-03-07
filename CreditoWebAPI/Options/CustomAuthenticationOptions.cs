using Microsoft.AspNetCore.Authentication;

namespace CreditoWebAPI.Options
{
    public static class CustomAuthenticationOptions
    {
        public static void SetupApiAuthentication(AuthenticationSchemeOptions options)
        {
            options.ClaimsIssuer = "CreditoWebAPI";
        }
    }
}

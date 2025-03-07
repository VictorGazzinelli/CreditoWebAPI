using Microsoft.AspNetCore.Authorization;

namespace CreditoWebAPI.Options
{
    public static class CustomAuthorizationOptions
    {
        public static void UseBasicAuthorization(AuthorizationOptions options)
        {
            options.AddPolicy("Basic", policy =>
            {
                policy.AuthenticationSchemes.Add("Basic");
                policy.RequireAuthenticatedUser();
            });
        }
    }
}

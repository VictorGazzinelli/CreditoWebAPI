using Microsoft.AspNetCore.Mvc;

namespace CreditoWebAPI.Options
{
    public static class CustomApiBehaviourOptions
    {
        public static void SuppressDefaultFilters(ApiBehaviorOptions apiBehaviorOptions)
        {
            apiBehaviorOptions.SuppressModelStateInvalidFilter = true;
            apiBehaviorOptions.SuppressMapClientErrors = true;
        }
    }
}

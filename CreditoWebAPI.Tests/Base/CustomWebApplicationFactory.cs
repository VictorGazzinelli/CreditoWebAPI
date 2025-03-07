using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;


namespace CreditoWebAPI.Tests.Base
{
    public class CustomWebApplicationFactory<TEntryPoint> : WebApplicationFactory<TEntryPoint> where TEntryPoint : class
    {
        protected override IHost CreateHost(IHostBuilder builder)
        {
            return base.CreateHost(builder);
        }
    }
}

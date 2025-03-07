using Xunit;

namespace CreditoWebAPI.Tests.Base
{
    public abstract class IntegrationTest : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        protected readonly HttpClient Client;

        public IntegrationTest(CustomWebApplicationFactory<Program> factory)
        {
            this.Client = factory.CreateClient();
        }
    }
}

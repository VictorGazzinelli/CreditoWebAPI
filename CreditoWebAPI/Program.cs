
namespace CreditoWebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);
            builder.Services.ConfigureApiServices();
            WebApplication app = builder.Build();
            app.ConfigureHttpRequestPipeline();
            app.Run();
        }
    }
}

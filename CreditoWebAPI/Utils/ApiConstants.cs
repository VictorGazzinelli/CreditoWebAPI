using System.Reflection;

namespace CreditoWebAPI.Utils
{
    public static class ApiConstants
    {
        public static string Name => Assembly.GetExecutingAssembly().GetName().Name;
        public static string Version => "v1";
        public static string AuthScheme => "Basic";
    }
}

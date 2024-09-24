using Microsoft.Extensions.Configuration;

namespace Leapspark.Gateway
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            var services = builder.Services;

            services.AddReverseProxy()
                .LoadFromConfig(configuration.GetSection("ReverseProxy"));

            var app = builder.Build();

            app.MapReverseProxy();

            app.Run();
        }
    }
}

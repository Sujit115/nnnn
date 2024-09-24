using Leapspark.Bootstrap.Application.Service.Extensions;
using Leapspark.Bootstrap.Application.Service.Extensions.MessageQueue.Extensions;
using Leapspark.Bootstrap.Services.MessageQueue.Dtos;
using Serilog;
using System.Diagnostics;

namespace Leapspark.Hub
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            var logstashUri = configuration.GetSection("logstash:uri").Get<string>();

            Serilog.Debugging.SelfLog.Enable(Console.Error);

            builder
                .Host
                .UseSerilog((x, y) =>
                {
                    y
                        .WriteTo.Http(logstashUri, queueLimitBytes: null)
                        .WriteTo.Console();
                });



            var rabbitMqConfiguration = configuration.GetSection("RabbitMq").Get<RabbitMqConfiguration>();

            var services = builder.Services;

            services
                .AddMessageQueue()
                .AddRabbitMq(rabbitMqConfiguration);

            services
                .AddSingleton<LeapsparkHub.LeapsparkHub>();

            var app = builder.Build();

            app
                .Use((x, y) =>
                {
                    x.RequestServices.GetRequiredService<LeapsparkHub.LeapsparkHub>();
                    return y();
                });

            app.MapGet("/", () => "Hello World Hub!");

            app.Run();
        }
    }
}

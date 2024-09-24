using ApplicationSecurityProvider.Helpers.Structs;
using ApplicationSecurityProvider.Middleware;
using ApplicationSecurityProvider.Models.Jwt;
using Leapspark.Auth.Events;
using Leapspark.Auth.Handlers;
using Leapspark.Auth.Services.Auth;
using Leapspark.Bootstrap.Application.Service.Extensions;
using Leapspark.Bootstrap.Application.Service.Extensions.MessageQueue.Extensions;
using Leapspark.Bootstrap.Services.MessageQueue.Dtos;

namespace Leapspark.Auth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            var configuration = builder.Configuration;

            var jwtSettings = configuration.GetSection("TokenConfiguration").Get<JwtSettings>();

            var rabbitMqConfiguration = configuration.GetSection("RabbitMq").Get<RabbitMqConfiguration>();

            services
                .AddEndpointsApiExplorer();

            services
                .AddSwaggerGen();

            services
                .AddAuthentication(AuthSchemes.Bearer)
                .AddImeBearerAuthentication(x =>
                {
                    x.UseSetting(jwtSettings);
                });

            services
                .AddSingleton<IAuthService, AuthService>();

            services
                .AddSingleton<Events.Events>();

            services
                .AddSingleton<LeapsparkAuthEventHandlers>();

            services
                .AddMessageQueue()
                .AddRabbitMq(rabbitMqConfiguration);

            services
                .AddControllers();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.Use((x,y) =>
            {
                x.RequestServices.GetRequiredService<LeapsparkAuthEventHandlers>();
                return y();
            });

            app.MapControllers();

            app.MapGet("/", () => "Hello World Auth!");

            app.Run();
        }
    }
}

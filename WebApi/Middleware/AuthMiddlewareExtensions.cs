using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using WebApi.Models.Configs;

namespace WebApi.Middleware
{
    public static class AuthMiddlewareExtensions
    {
        public static IApplicationBuilder UseTokenCookie(this IApplicationBuilder app)
        {
            app.Use(async (context,
                           next) =>
            {
                // https://habr.com/ru/post/468401/
                var token = context.Request.Cookies["Authorization"];
                if (!string.IsNullOrEmpty(token))
                    context.Request.Headers.Add("Authorization", token);

                await next();
            });

            return app;
        }
        
        public static IServiceCollection UseJwtAuth(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtTokenConfig = configuration.Get<WebApiRootConfig>().JwtTokenConfig;
            services.AddSingleton(jwtTokenConfig);
            
            services
               .AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
               .AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = true;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwtTokenConfig.Issuer,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = jwtTokenConfig.SymmetricSecurityKey,
                        ValidAudience = jwtTokenConfig.Audience,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.FromMinutes(1)
                    };
                });

            return services;
        }
        
        public static IApplicationBuilder UseSecureHeaders(this IApplicationBuilder app)
        {
            app.Use(async (context, next) =>
            {
                // https://habr.com/ru/post/468401/
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Xss-Protection", "1");
                context.Response.Headers.Add("X-Frame-Options", "DENY");

                await next();
            });

            return app;
        }
    }
}
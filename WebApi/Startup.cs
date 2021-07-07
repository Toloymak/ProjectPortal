using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;
using WebApi.Middleware;
using WebApi.Services;
using SameSiteMode = Microsoft.AspNetCore.Http.SameSiteMode;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            RegisterDependencies(services, Configuration);
            services.AddCors(o =>
            {
                o.AddPolicy("AllowSpecificOrigin",
                            builder => builder
                               .WithOrigins("http://localhost:5000", "https://localhost:5001")
                               .WithHeaders(HeaderNames.ContentType, HeaderNames.Authorization, "x-custom-header")
                               .AllowAnyMethod()
                               .AllowCredentials());
            });
            
            services.AddControllers();
            services.UseJwtAuth(Configuration);
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebApi", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseHttpsRedirection()
               .UseCors("AllowSpecificOrigin")
               .UseRouting()
               .UseTokenCookie()
               .UseSecureHeaders()
               .UseCookiePolicy(new CookiePolicyOptions()
                {
                    HttpOnly = HttpOnlyPolicy.Always,
                    Secure = CookieSecurePolicy.Always,
                    MinimumSameSitePolicy = SameSiteMode.None,
                });
            
            app.UseAuthentication()
               .UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("default", "{controller}/{action=Get}");
                endpoints.MapControllers();
            }); 
        }

        public void RegisterDependencies(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IJwtAuthService, JwtAuthService>();
        }
    }
}

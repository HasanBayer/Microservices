using System.IO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Ocelot.Configuration;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Values;

namespace OcelotBasic
{
    public class Program
    {
        public void ConfigureServices(IServiceCollection services)
        {
            var authenticationProviderKey = "GatewayAuthenticationScheme";
            services.AddAuthentication().AddJwtBearer(authenticationProviderKey, options =>
                 {
                     options.Authority = "IdentityServerURL";
                     options.Audience = "resource_gateway";
                     options.RequireHttpsMetadata = false;
                 });
            services.AddOcelot();
        }


        public static void Main(string[] args)
        {
            new WebHostBuilder()
            .UseKestrel()
            .UseContentRoot(Directory.GetCurrentDirectory())
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                    .SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
                    .AddJsonFile("appsettings.json", true, true)
                    .AddJsonFile($"configuration.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
                    //.AddJsonFile("ocelot.json")
                    .AddEnvironmentVariables();
            })




            .ConfigureLogging((hostingContext, logging) =>
            {
                //add your logging
            })
            .UseIISIntegration()
            .Configure(app =>
            {

                app.UseOcelot();
            })
            .Build()
            .Run();
        }
    }
}

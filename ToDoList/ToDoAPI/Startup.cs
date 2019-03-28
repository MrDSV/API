using System.Linq;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Http;
using ToDoAPI.Configuration;
using ToDoAPI.Services;

namespace ToDoAPI
{
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using System.Security.Cryptography.X509Certificates;

    class Startup
    {
       /* public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }*/

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityServer()
                .AddSigningCredential(new X509Certificate2(@"C:\dev\todoResources.pfx", ""))
                .AddTestUsers(InMemoryConfiguration.Users().ToList())
                .AddInMemoryClients(InMemoryConfiguration.Clients())
                .AddInMemoryApiResources(InMemoryConfiguration.ApiResources());
            

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "http://localhost:5000";
                    options.RequireHttpsMetadata = false;
                    options.SaveToken = true;
                    options.ApiName = "todoResources";
                    options.ApiSecret = "SKB Kontur";
                });

            services.AddScoped<ToDoService>();
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder appBuilder)
        {
            //appBuilder.UseDeveloperExceptionPage();
            appBuilder.UseIdentityServer();
            appBuilder.UseAuthentication();
            appBuilder.UseMvc();
        }
    }
}

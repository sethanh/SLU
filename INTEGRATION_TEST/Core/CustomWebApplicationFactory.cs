using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace SALON_HAIR_TEST_CORE
{
    public class ManagementServerFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        public IServiceCollection ServiceCollection { get; private set; }
        public IServiceProvider ServiceProvider { get => Server.Host.Services; }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test");
            builder.UseStartup<TProgram>();
        }
    }
}

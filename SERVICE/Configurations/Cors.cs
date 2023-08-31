using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SERVICE.Configurations
{
    public class Cors
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                      .AllowAnyMethod()
                      .AllowAnyHeader()
                      .WithExposedHeaders("Content-Disposition")
                .Build());
            });
        }

        public static void Configure(IApplicationBuilder app)
        {
            app.UseCors("CorsPolicy");
        }
    }
}

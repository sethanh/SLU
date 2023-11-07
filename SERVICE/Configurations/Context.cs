using DATA.CONTEXT;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SERVICE.Configurations
{
    public static class Context
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            string mySqlConnectionStr = configuration.GetConnectionString("DefaultConnection");
            services.AddDbContextPool<MainDbContext>(
                options => options.UseMySql(
                    mySqlConnectionStr,
                    ServerVersion.AutoDetect(mySqlConnectionStr),
                    b => b.MigrationsAssembly("MIGRATION")
                )
            );
        }
    }
}

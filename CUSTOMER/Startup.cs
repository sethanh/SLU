using CUSTOMER.Basic;
using Microsoft.AspNetCore.Identity;
using SERVICE.Configurations;

namespace CUSTOMER
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Cors.ConfigureServices(services);

            Context.ConfigureServices(services, Configuration);

            Authentication.ConfigureServices(
                services,
                Configuration,
                EventType: typeof(CustomerValidation)
             );

            services.AddControllers();
            SERVICE.CoreDependenciesInjection.Inject(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            Authentication.ConfigureApp(app);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

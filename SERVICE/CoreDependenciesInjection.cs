using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using DATA;

namespace SERVICE
{
    public static class CoreDependenciesInjection
    {
        public static void Inject(IServiceCollection services)
        {
            services.AddScoped<UnitOfWork>();
            DomainServiceRegister.Register(services);
            ApplicationServiceRegister.Register(services);
        }
    }
}

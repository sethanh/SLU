using Microsoft.Extensions.DependencyInjection;
using SERVICE.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE
{
    public static class ApplicationServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<UserServices>();
        }
    }
}

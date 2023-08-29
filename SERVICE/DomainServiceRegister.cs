using Microsoft.Extensions.DependencyInjection;
using SERVICE.Managers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE
{
    public static class DomainServiceRegister
    {
        public static void Register(IServiceCollection services)
        {
            services.AddScoped<UserManager>();
        }
    }
}

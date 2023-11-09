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
            services.AddScoped<UserService>();
            services.AddScoped<AuthenticationService>();

            services.AddScoped<ShopBranchService>();
            services.AddScoped<ShopService>();

            services.AddScoped<CustomerService>();
            services.AddScoped<CustomerAccountService>();

            services.AddScoped<BookingService>();
            services.AddScoped<BookingDetailCoreService>();
            services.AddScoped<BookingDetailServiceService>();

            services.AddScoped<ServiceService>();
        }
    }
}

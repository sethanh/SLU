﻿using Microsoft.Extensions.DependencyInjection;
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

            services.AddScoped<ShopBranchManager>();
            services.AddScoped<ShopManager>();

            services.AddScoped<CustomerManager>();
            services.AddScoped<CustomerAccountManager>();

            services.AddScoped<BookingManager>();
            services.AddScoped<BookingDetailManager>();
            services.AddScoped<BookingDetailObjectManager>();

            services.AddScoped<ServiceManager>();
            
            services.AddScoped<AppModuleManager>();
            services.AddScoped<AppModulePermissionManager>();
        }
    }
}

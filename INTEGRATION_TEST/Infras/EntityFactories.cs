using DATA;
using DATA.EF_CORE;
using INTEGRATION_TEST.Factories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INTEGRATION_TEST.Infras
{
    public class EntityFactories
    {
        public UserFactory User {  get; protected set; }

        public EntityFactories(IServiceProvider serviceProvider, HttpClient apiClient)
        {
            var unitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();

            User = new UserFactory(serviceProvider);
           
        }
    }
}

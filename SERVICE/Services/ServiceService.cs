using DATA.EF_CORE;
using SERVICE.Dtos.Services;
using SERVICE.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Services
{
    public class ServiceService : ApplicationService<Service>
    {
        public ServiceService(ServiceManager domainService) : base(domainService)
        {
        }

        public Service CreateService(ServiceDto model, string createBy) 
        {
            var service = new Service
            {
                Name = model.Name,
                Price = model.Price ?? 0,
                Code = model.Code,
                TimeUnit = model.TimeUnit,
                TimeValue = model.TimeValue,
                Description = model.Description,
                CreatedBy = createBy,
                ShopId = model.ShopId,
                ShopBranchId = model.ShopBranchId
            };

            Add(service);

            return service;
        }
    }
}

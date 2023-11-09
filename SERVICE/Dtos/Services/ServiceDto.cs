using DATA.EF_CORE;
using DATA.Enums;
using SERVICE.Dtos.BookingDetailObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.Services
{
    public class ServiceDto
    {
        public long? Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public decimal? Price { get; set; }
        public string TimeUnit { get; set; } = TIME_UNIT.MINUTE;
        public int? TimeValue { get; set; }
        public long? ShopId { get; set; }
        public long? ShopBranchId { get; set; }

        public static ServiceDto Create(Service service)
        {
            return new ServiceDto
            {
                Id = service.Id,
                Description = service.Description,
                Name = service.Name,
                Code = service.Code,
                Price = service.Price,
                TimeUnit = service.TimeUnit,
                TimeValue = service.TimeValue,
                ShopId = service.ShopId,
                ShopBranchId = service.ShopBranchId,
            };
        }

        public static List<ServiceDto> Create(List<Service> services)
        {
            var result = services.Select(c => Create(c)).ToList();
            return result;
        }

    }
}

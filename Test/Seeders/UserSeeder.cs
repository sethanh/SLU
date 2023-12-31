﻿using SERVICE.Dtos.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test.Seeders
{
    public partial class SeederBase
    {
        public async Task<SeedData> SeedService(decimal? price = 0)
        {
            var service = await _factories.Service.Create(new ServiceDto { Price = price });

            return new SeedData
            {
                Service = service
            };
        }
    }
}

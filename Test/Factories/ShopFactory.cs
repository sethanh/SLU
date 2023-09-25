using Bogus;
using DATA.EF_CORE;
using SERVICE.Dtos.Shops;
using SERVICE.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Utils;

namespace Test.Factories
{
    public class ShopFactory
    {
        public ShopService ShopService { get; private set; }

        public ShopFactory(IServiceProvider serviceProvider)
        {
            ShopService = (ShopService)serviceProvider.GetService(typeof(ShopService));
        }

        private static ShopDto FakeForCreate()
        {
            return new Faker<ShopDto>()
                .RuleFor(c => c.Name, f => f.Company.CompanyName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.PassWord, f => f.Random.String2(10))
                .RuleFor(c => c.RegisterEmail, f => f.Internet.Email());
        }

        public ShopDto Create(ShopDto shop)
        {
            var fake = FakeForCreate();
            ObjectUtils.CopyValues(shop, fake);
            return ShopService.InitialShop(fake);
        }
    }
}

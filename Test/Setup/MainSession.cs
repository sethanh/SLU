using DATA.EF_CORE;
using SERVICE.Dtos.Shops;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Factories;

namespace Test.Setup
{
    public class MainSession
    {
        private readonly ShopFactory _shopFactory;

        public Shop Shop { get; protected set; }
        public ShopBranch ShopBranch { get; protected set; }
        public User User { get; protected set; }

        public MainSession(IServiceProvider serviceProvider)
        {
            _shopFactory = new ShopFactory(serviceProvider);
            RegisterShop();
        }

        private void RegisterShop()
        {
            var shop = _shopFactory.Create( new ShopDto { });

            ShopBranch = shop.ShopBranchs.First();
            User = shop.Users.First();
            Shop = shop;
        }
    }
}

using DATA.EF_CORE;
using Microsoft.IdentityModel.Tokens;
using SERVICE.Dtos.Shops;
using SERVICE.Managers;
using System;
using System.Collections.Generic;

namespace SERVICE.Services
{
    public class ShopService : ApplicationService<Shop>
    {
        private readonly ShopBranchService _shopBranchService;
        private readonly UserService _userService;
        public ShopService(
            ShopManager domainService,
            ShopBranchService shopBranchService,
            UserService userService
            ) : base(domainService)
        {
            _shopBranchService = shopBranchService;
            _userService = userService;
        }

        public ShopDto InitialShop(
            ShopDto shop
            )
        {
            Add(shop);

            var mainShopBranch = new ShopBranch
            {
                Name = shop.Name,
                Address = shop.Address,
                Region = shop.Region,
                City = shop.City,
                Fax = shop.Fax,
                Phone = shop.Phone,
                OpenTime = shop.OpenTime,
                CloseTime = shop.CloseTime,
                Created = DateTime.Now,
                Updated = DateTime.Now,
                ShopId = shop.Id,
                MainBranch = true
            };

            _shopBranchService.Add( mainShopBranch );

            var rootUser = new User
            {
                Email = shop.RegisterEmail,
                Password = shop.PassWord,
                ShopBranchId = mainShopBranch.Id,
                ShopId = shop.Id
            };

            _userService.Add(rootUser);

            shop.ShopBranchs = new List<ShopBranch>() { mainShopBranch};
            shop.Users = new List<User>() { rootUser };

            return shop;
        }
    }
}

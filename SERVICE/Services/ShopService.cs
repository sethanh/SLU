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
        private readonly ShopBranchManager _shopBranchManager;
        private readonly UserManager _userManager;
        public ShopService(
            ShopManager domainService,
            ShopBranchManager shopBranchManager,
            UserManager userManager
            ) : base(domainService)
        {
            _shopBranchManager = shopBranchManager;
            _userManager = userManager;
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

            _shopBranchManager.Add(mainShopBranch, saveChange: true);

            var rootUser = new User
            {
                Email = shop.RegisterEmail,
                Password = shop.PassWord,
                ShopBranchId = mainShopBranch.Id,
                ShopId = shop.Id
            };

            _userManager.Add(rootUser, saveChange: true);

            shop.ShopBranches = new List<ShopBranch>() { mainShopBranch};
            shop.Users = new List<User>() { rootUser };

            return shop;
        }
    }
}

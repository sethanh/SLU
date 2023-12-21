using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.Shops
{
    public class ShopDto : Shop
    {
        public string RegisterEmail { get; set; }
        public string PassWord { get; set; }
        public List<ShopBranchDto> Branches { get; set; }

        public static ShopDto Create(Shop shop)
        {
            if (shop == null)
            {
                return null;
            }

            return new ShopDto 
            {
                Id = shop.Id,
                Since = shop.Since,
                Name = shop.Name,
                Address = shop.Address,
                Phone = shop.Phone,
                Logo = shop.Logo,
                OpenTime = shop.OpenTime,
                CloseTime = shop.CloseTime,
                CoverPicture = shop.CoverPicture,
                Fax = shop.Fax,
                Country = shop.Country,
                Status = shop.Status,
                Region = shop.Region,
                City = shop.City,
                CreatedBy = shop.CreatedBy,
                UpdatedBy = shop.UpdatedBy,
                Branches = ShopBranchDto.Create(shop?.ShopBranches?.ToList() ?? new List<ShopBranch>())
            };
        }
    }
}

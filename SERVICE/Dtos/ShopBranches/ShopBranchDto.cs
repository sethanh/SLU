using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.Shops
{
    public class ShopBranchDto : ShopBranch
    {
        public static ShopBranchDto Create(ShopBranch shopBranch)
        {
            if(shopBranch == null)
            {
                return null;
            }

            return new ShopBranchDto
            {
                Id = shopBranch.Id,
                Name = shopBranch.Name,
                Address = shopBranch.Address,
                City = shopBranch.City,
                Region = shopBranch.Region,
                PostalCode = shopBranch.PostalCode,
                Country = shopBranch.Country,
                Phone = shopBranch.Phone,
                Fax = shopBranch.Fax,
                MainBranch = shopBranch.MainBranch,
                OpenTime = shopBranch.OpenTime,
                CloseTime = shopBranch.CloseTime,
                ShopId = shopBranch.ShopId
            };
        }
        
        public static List<ShopBranchDto> Create(List<ShopBranch> shopBranches)
        {
            var results = new List<ShopBranchDto>();
        
            if(shopBranches.Count == 0)
            {
                return results;
            }

            foreach(var shopBranch in shopBranches)
            {
                var shopBranchDto = Create(shopBranch);
                results.Add(shopBranchDto);
            }

            return results;
        }
    }
}

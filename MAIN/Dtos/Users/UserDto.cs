using DATA.EF_CORE;
using DATA.Enums;
using System.Collections.Generic;

namespace MAIN.Dtos.Users
{
    public class UserDto : User
    {
        public static UserDto Create(User user)
        {
            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Password = SECURITY_VALUE.PASSWORD,
                UserGroupId = user.UserGroupId,
                ShopBranchId = user.ShopBranchId,
                ShopId = user.ShopId,
                Status = user.Status,
            };
        }

        public static List<UserDto> Create(List<User> users)
        {
            var result = new List<UserDto>();
            foreach (var user in users)
            {
                result.Add(Create(user));
            }

            return result;
        }
    }
}

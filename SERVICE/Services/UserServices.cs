using System;
using System.Linq;
using DATA.EF_CORE;
using DATA.Enums;
using SERVICE.Dtos.Users;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class UserService : ApplicationService<User>
    {        
        public UserService(
            UserManager domainService
            ) : base(domainService)
        {

        }

        public User CreateUser(
            UserDto model,
            long CurrentShopId,
            long CurrentShopBranchId
            )
        {
            var lengthPassword = model.Password.Length;

            if (lengthPassword < SECURITY_VALUE.MIN_LENGTH)
            {
                throw new Exception(BAD_REQUEST_MESSAGE.PASSWORD_IS_NOT_VALID);
            }

            var newUser = new User
            {
                Name = model.Name,
                Email = model.Email,
                Password = model.Password,
                UserGroupId = model.UserGroupId,
                ShopId = CurrentShopId,
                ShopBranchId = CurrentShopBranchId
            };

            Add(newUser);

            return newUser;
        }

        public User UpdateUser(
            UserDto model,
            long userId,
            string updatedBy
            )
        {
            var user = GetAll().FirstOrDefault(u => u.Id == userId);

            if (user == null)
            {
                throw new Exception(EXCEPTION_TYPE.NOT_FOUND);
            }

            user.Name = model.Name ?? user.Name;
            user.Email = model.Email ?? user.Email;
            user.Password = model.Password != SECURITY_VALUE.PASSWORD ? model.Password : user.Password;
            user.UserGroupId = model.UserGroupId ?? user.UserGroupId;
            user.Updated = DateTime.Now;
            user.UpdatedBy = updatedBy;     

            Update(user);

            return user;
        }
    }
}

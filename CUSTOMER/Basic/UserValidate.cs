using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SERVICE.Services;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CUSTOMER.Basic
{
    public class CustomerValidation : JwtBearerEvents
    {
        public override Task TokenValidated(TokenValidatedContext context)
        {
            //var userService = context.HttpContext.RequestServices.GetRequiredService<UserServices>();
            //string userIdStr = context.Principal.FindFirstValue("userId");
            //if (string.IsNullOrEmpty(userIdStr))
            //{
            //    context.Fail("INVALID_USER_ID");
            //}

            //var userId = long.Parse(userIdStr);
            //var securityStamp = context.Principal.FindFirstValue("SecurityStamp");
            //var user = userService.GetAll().Include(o => o.Salon).AsNoTracking().FirstOrDefault(x => x.Id == userId);

            //if (user == null)
            //{
            //    context.Fail("USER_DELETED");
            //    return Task.CompletedTask;
            //}

            //if (user.Salon == null)
            //{
            //    context.Fail("SALON_DELETED");
            //    return Task.CompletedTask;
            //}

            //if (securityStamp != user.SecurityStamp)
            //{
            //    context.Fail("SECURITY_STAMP_MISMATCH");
            //    return Task.CompletedTask;
            //}

            context.Success();

            return Task.CompletedTask;
        }
    }
}

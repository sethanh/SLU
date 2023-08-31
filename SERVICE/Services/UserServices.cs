using DATA.EF_CORE;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class UserServices : ApplicationService<User>
    {
        public UserServices(
            UserManager domainService
            ) : base(domainService)
        {

        }
    }
}

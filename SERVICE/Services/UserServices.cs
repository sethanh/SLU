using DATA.EF_CORE;
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
    }
}

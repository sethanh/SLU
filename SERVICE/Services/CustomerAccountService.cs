using DATA.EF_CORE;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class CustomerAccountService : ApplicationService<CustomerAccount>
    {
        public CustomerAccountService(
            CustomerAccountManager domainService
            ) : base(domainService)
        {

        }
    }
}

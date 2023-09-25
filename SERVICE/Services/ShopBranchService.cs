using DATA.EF_CORE;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class ShopBranchService : ApplicationService<ShopBranch>
    {
        public ShopBranchService(
            ShopBranchManager domainService
            ) : base(domainService)
        {

        }
    }
}

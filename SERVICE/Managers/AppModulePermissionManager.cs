using DATA;
using DATA.EF_CORE;

namespace SERVICE.Managers;

public class AppModulePermissionManager : DomainService<AppModulePermission>
{
    public AppModulePermissionManager(UnitOfWork unitOfWork) : base(unitOfWork) { }
}

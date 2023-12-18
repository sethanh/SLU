using DATA.EF_CORE;
using SERVICE.Managers;

namespace SERVICE.Services;

public class AppModulePermissionService:ApplicationService<AppModulePermission>
{
    public AppModulePermissionService(AppModulePermissionManager domainService): base(domainService) { }
}

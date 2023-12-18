using DATA;
using DATA.EF_CORE;
using SERVICE.Managers;

namespace SERVICE.Services;

public class AppModuleService: ApplicationService<AppModule>
{
    public AppModuleService(AppModuleManager domainService) : base(domainService) { }
}

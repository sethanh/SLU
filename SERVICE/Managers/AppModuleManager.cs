using DATA;
using DATA.EF_CORE;

namespace SERVICE.Managers;

public class AppModuleManager : DomainService<AppModule>
{
    public AppModuleManager(UnitOfWork unitOfWork) : base(unitOfWork) { }
}

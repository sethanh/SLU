using DATA.EF_BASE;

namespace DATA.EF_CORE;

public class AppModulePermission : EntitiesShopNoBranch
{
    public bool Allowed { get; set; }
    public bool Enabled { get; set; }
    public long AppModuleId { get; set; }
    public AppModule AppModule { get; set; }
}

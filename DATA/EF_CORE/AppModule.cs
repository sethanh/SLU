using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DATA.EF_BASE;

namespace DATA.EF_CORE;

public class AppModule: EntitiesBase
{
    public string Code { get; set; }
    
    [Column(TypeName = "nvarchar(250)")]
    public string Name { get; set; }

    public ICollection<AppModulePermission> AppModulePermissions { get; set; }
}

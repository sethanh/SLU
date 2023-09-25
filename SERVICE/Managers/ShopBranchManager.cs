using DATA;
using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE.Managers
{ 
    public class ShopBranchManager : DomainService<ShopBranch>
    {
        public ShopBranchManager(UnitOfWork unitOfWork): base(unitOfWork) { }
    }
}

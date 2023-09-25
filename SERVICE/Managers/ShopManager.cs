using DATA;
using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE.Managers
{ 
    public class ShopManager : DomainService<Shop>
    {
        public ShopManager(UnitOfWork unitOfWork): base(unitOfWork) { }
    }
}

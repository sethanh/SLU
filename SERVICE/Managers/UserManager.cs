using DATA;
using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE.Managers
{ 
    public class UserManager : DomainService<User>
    {
        public UserManager(UnitOfWork unitOfWork): base(unitOfWork) { }
    }
}

using DATA;
using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Text;

namespace SERVICE.Managers
{ 
    public class CustomerManager : DomainService<Customer>
    {
        public CustomerManager(UnitOfWork unitOfWork): base(unitOfWork) { }
    }
}

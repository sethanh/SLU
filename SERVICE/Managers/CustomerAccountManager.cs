using DATA;
using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICE.Managers
{ 
    public class CustomerAccountManager : DomainService<CustomerAccount>
    {
        public CustomerAccountManager(UnitOfWork unitOfWork): base(unitOfWork) { }

        public CustomerAccount FindWithMobile(string mobile)
        {
            var customerAccount = GetAll().FirstOrDefault(c => c.Mobile == mobile);

            return customerAccount;
        }
    }

}

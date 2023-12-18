using DATA;
using DATA.EF_CORE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SERVICE.Managers
{ 
    public class CustomerManager : DomainService<Customer>
    {
        public CustomerManager(UnitOfWork unitOfWork): base(unitOfWork) { }

        public List<Customer> UpdateWithCustomerAccount(CustomerAccount customerAccount)
        {
            var existCustomers = GetAll().Where(c => c.Mobile == customerAccount.Mobile).ToList();

            existCustomers.ForEach(c => {c.CustomerAccountId = customerAccount.Id;});

            UpdateRange(existCustomers);

            return existCustomers;
        }
    }
}

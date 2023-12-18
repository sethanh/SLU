using System.Collections.Generic;
using System.Linq;
using DATA.EF_CORE;
using SERVICE.Dtos.Customers;
using SERVICE.Managers;


namespace SERVICE.Services
{
    public class CustomerService : ApplicationService<Customer>
    {
        private readonly CustomerAccountManager _customerAccountManager;
        public CustomerService(
            CustomerManager domainService, 
            CustomerAccountManager customerAccountManager
            ) : base(domainService)
        {
            _customerAccountManager = customerAccountManager;
        }

        public Customer CreateCustomer(CustomerDto model, long shopId)
        {
            var existCustomerAccount = _customerAccountManager.FindWithMobile(model.Mobile);

            var newCustomer = new Customer
            {
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                Mobile = model.Mobile,
                Sex = model.Sex,
                AvatarUrl = model.AvatarUrl,
                ShopId = shopId,
                Note = model.Note,
                Code = model.Code,
                Dob = model.Dob,
                CustomerAccountId = existCustomerAccount?.Id
            };

            Add(newCustomer);

            return newCustomer;
        }
    }
}

using DATA.EF_CORE;
using SERVICE.Dtos.CustomerAccounts;
using SERVICE.Helpers;
using SERVICE.Managers;
using System.Linq;

namespace SERVICE.Services
{
    public class CustomerAccountService : ApplicationService<CustomerAccount>
    {
        private readonly CustomerManager _customerManager;
        public CustomerAccountService(
            CustomerAccountManager domainService,
            CustomerManager customerManager
            ) : base(domainService)
        {
            _customerManager = customerManager;
        }

        public CustomerAccount CreateCustomerAccount(CustomerAccountDto model)
        {
            var mobileCustomers = _customerManager.GetAll().Where(c => c.Mobile == model.Mobile).ToList();
            var newCustomerAccount = new CustomerAccount
            {
                Mobile = model.Mobile,
                Name = model.Name,
                Email = model.Email,
                Address = model.Address,
                Gender = model.Gender,
                CustomerCode = model.CustomerCode,
                Password = model.Password
            };

            Add(newCustomerAccount);

            mobileCustomers.ForEach(c => { c.CustomerAccountId = newCustomerAccount.Id;});

            _customerManager.UpdateRange(mobileCustomers, saveChange: true);

            return newCustomerAccount;
        }

        public string GetJwtSecurityToken(
            CustomerAccount customerAccount,
            string jwtKeyString,
            string jwtIssuer
            )
        {
            var token = AuthenticationHelper.GetCustomerJwtSecurityToken(
                customerAccount,
                jwtKeyString,
                jwtIssuer
            );

            return token;
        }
    }
}

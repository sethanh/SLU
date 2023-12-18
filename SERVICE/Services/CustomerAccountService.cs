using DATA.EF_CORE;
using DATA.Enums;
using Microsoft.Extensions.Configuration;
using SERVICE.Dtos.Authentications;
using SERVICE.Dtos.CustomerAccounts;
using SERVICE.Helpers;
using SERVICE.Managers;
using System;
using System.Linq;

namespace SERVICE.Services
{
    public class CustomerAccountService : ApplicationService<CustomerAccount>
    {
        private readonly CustomerManager _customerManager;
        private readonly IConfiguration _config;
        private const int minLengthPassword = 6;
        public CustomerAccountService(
            IConfiguration config,
            CustomerAccountManager domainService,
            CustomerManager customerManager
            ) : base(domainService)
        {
            _customerManager = customerManager;
            _config = config;
        }

        public string GetJwtKeyString()
        {
            return _config["Jwt:Key"];
        }

        public string GetJwtIssuer()
        {
            return _config["Jwt:Issuer"];
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

        public CustomerAuthenticateResponse GetAuthResponse(
            CustomerAuthenticateRequest model
            )
        {
            var customerAccount = GetAll().FirstOrDefault(u => u.Mobile == model.Mobile && u.Password == model.Password);

            if (customerAccount == null)
            {
               throw new Exception(EXCEPTION_TYPE.NOT_FOUND);
            }

            var token = AuthenticationHelper.GetCustomerJwtSecurityToken(
                customerAccount,
                GetJwtKeyString(),
                GetJwtIssuer()
            );
            
            var AuthResponse =  CustomerAuthenticateResponse.Create(customerAccount, token);

            return AuthResponse;
        }

        public CustomerAuthenticateResponse RegisterCustomerAccount(
            CustomerAccountRegister customerRegister
            )
        {
            var customerAccount = GetAll()
                .FirstOrDefault(u => u.Mobile == customerRegister.Mobile);

            if (customerAccount != null)
            {
                throw new Exception(BAD_REQUEST_MESSAGE.EXISTED_CUSTOMER);
            }

            var lengthPassword = customerRegister.Password.Length;

            if (lengthPassword < minLengthPassword)
            {
                throw new Exception(BAD_REQUEST_MESSAGE.PASSWORD_IS_NOT_VALID);
            }

            var newCustomerAccount = new CustomerAccount
            {
                Name = customerRegister.Name,
                Password = customerRegister.Password,
                Mobile = customerRegister.Mobile,
                Gender = customerRegister.Gender,
                IsVerify = true
            };

            Add(newCustomerAccount);

            _customerManager.UpdateWithCustomerAccount(newCustomerAccount);

            var token = AuthenticationHelper.GetCustomerJwtSecurityToken(
                newCustomerAccount,
                GetJwtKeyString(),
                GetJwtIssuer()
            );

            var AuthResponse =  CustomerAuthenticateResponse.Create(newCustomerAccount, token);

            return AuthResponse;
        }
    }
}

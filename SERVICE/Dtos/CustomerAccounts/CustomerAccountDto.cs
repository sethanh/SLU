using DATA.EF_CORE;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.CustomerAccounts
{
    public class CustomerAccountDto
    {
        public long? Id { get; set; }
        public string Address { get; set; }
        public DateTime? Birthday { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string CustomerCode { get; set; }
        public string Password { get; set; }

        public static CustomerAccountDto CopyValueFromEntity(CustomerAccount CustomerAccount)
        {
            return new CustomerAccountDto
            {
                Id = CustomerAccount.Id,
                Address = CustomerAccount.Address,
                Birthday = CustomerAccount.Birthday,
                Email = CustomerAccount.Email,
                Mobile = CustomerAccount.Mobile,
                Name = CustomerAccount.Name,
                Gender = CustomerAccount.Gender,
                CustomerCode = CustomerAccount.CustomerCode
            };
        }

        public static List<CustomerAccountDto> CopyValueFromEntity(List<CustomerAccount> CustomerAccounts)
        {
            var CustomerAccountDtos = new List<CustomerAccountDto>();

            foreach(var CustomerAccount in CustomerAccounts)
            {
                CustomerAccountDtos.Add(CopyValueFromEntity(CustomerAccount));
            }

            return CustomerAccountDtos;
        }
    }
}

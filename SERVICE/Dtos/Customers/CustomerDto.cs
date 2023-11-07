using DATA.EF_CORE;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Dtos.Customers
{
    public class CustomerDto
    {
        public long? Id { get; set; }
        public string Address { get; set; }
        public DateTime? Dob { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public string Sex { get; set; }
        public string AvatarUrl { get; set; }
        public string Code { get; set; }
        public long? ShopId { get; set; }
        public long? CustomerAccountId { get; set; }

        public static CustomerDto CopyValueFromEntity(Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                Address = customer.Address,
                Dob = customer.Dob,
                Email = customer.Email,
                Mobile = customer.Mobile,
                Name = customer.Name,
                Note = customer.Note,
                Sex = customer.Sex,
                AvatarUrl = customer.AvatarUrl,
                Code = customer.Code,
                ShopId = customer.ShopId,
            };
        }

        public static List<CustomerDto> CopyValueFromEntity(List<Customer> customers)
        {
            var customerDtos = new List<CustomerDto>();

            foreach(var customer in customers)
            {
                customerDtos.Add(CopyValueFromEntity(customer));
            }

            return customerDtos;
        }
    }
}

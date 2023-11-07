using Bogus;
using DATA;
using DATA.EF_CORE;
using SERVICE.Dtos.Customers;
using Test.Infras;

namespace Test.Factories
{
    public class CustomerFactory : HttpFactoryBase<Customer, CustomerDto>
    {
        public override string CreateUri => "Customers";

        public CustomerFactory(HttpClient apiClient, Repository<Customer> repository) : base(apiClient, repository)
        {
        }

        public override CustomerDto FakeDto()
        {
            return new Faker<CustomerDto>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Email, f => f.Internet.Email())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.Mobile, f => f.Phone.PhoneNumber().Replace(" ", string.Empty));
        }
    }
}

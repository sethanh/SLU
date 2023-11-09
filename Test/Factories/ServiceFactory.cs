using Bogus;
using DATA;
using DATA.EF_CORE;
using SERVICE.Dtos.Services;
using Test.Infras;

namespace Test.Factories
{
    public class ServiceFactory : HttpFactoryBase<Service, ServiceDto>
    {
        public override string CreateUri => "Services";

        public ServiceFactory(HttpClient apiClient, Repository<Service> repository) : base(apiClient, repository)
        {
        }

        public override ServiceDto FakeDto()
        {
            return new Faker<ServiceDto>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Description, f => f.Random.String2(10));
        }
    }
}

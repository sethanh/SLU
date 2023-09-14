

namespace INTEGRATION_TEST.Factories
{
    public class AuthenticationFactory : HttpFactoryBase<Product, ProductCreateDto>
    {
        public override string CreateUri => "/products";

        public AuthenticationFactory(HttpClient apiClient, Repository<Product> repository) : base(apiClient, repository)
        {
        }

        public override ProductCreateDto FakeDto()
        {
            return new Faker<ProductCreateDto>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Price, f => f.PickRandom<decimal>(10_000, 20_000, 50_000));
        }
    }
}
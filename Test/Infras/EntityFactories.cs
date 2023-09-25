using DATA;
using Microsoft.Extensions.DependencyInjection;
using Test.Factories;

namespace Test.Infras
{
    public class EntityFactories
    {
        public ShopFactory Shop { get; protected set; }

        public EntityFactories(IServiceProvider serviceProvider, HttpClient apiClient)
        {
            var unitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();

            Shop = new ShopFactory(serviceProvider);
        }
    }
}

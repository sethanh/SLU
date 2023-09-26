using DATA;
using DATA.EF_CORE;
using Microsoft.Extensions.DependencyInjection;
using Test.Factories;

namespace Test.Infras
{
    public class EntityFactories
    {
        public ShopFactory Shop { get; protected set; }
        public UserFactory User { get; protected set; }

        public EntityFactories(IServiceProvider serviceProvider, HttpClient apiClient)
        {
            var unitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();

            Shop = new ShopFactory(serviceProvider);
            User = new UserFactory(apiClient, unitOfWork.GetRepository<User>());
        }
    }
}

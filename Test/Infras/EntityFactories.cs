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
        public CustomerFactory Customer { get; protected set; }
        public ServiceFactory Service { get; protected set; }

        public EntityFactories(IServiceProvider serviceProvider, HttpClient apiClient)
        {
            var unitOfWork = serviceProvider.GetRequiredService<UnitOfWork>();

            Shop = new ShopFactory(serviceProvider);
            User = new UserFactory(apiClient, unitOfWork.GetRepository<User>());
            Customer = new CustomerFactory(apiClient, unitOfWork.GetRepository<Customer>());
            Service = new ServiceFactory(apiClient, unitOfWork.GetRepository<Service>());
        }
    }
}

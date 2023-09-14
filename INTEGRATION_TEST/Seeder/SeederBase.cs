using INTEGRATION_TEST.Infras;

namespace INTEGRATION_TEST.Seeder
{
    public partial class SeederBase
    {
        private readonly EntityFactories _factories;

        public SeederBase(EntityFactories entityFactories)
        {
            _factories = entityFactories;
        }
    }
}

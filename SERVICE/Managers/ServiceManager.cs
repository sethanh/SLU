using DATA.EF_CORE;
using DATA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SERVICE.Managers
{
    public class ServiceManager : DomainService<Service>
    {
        public ServiceManager(UnitOfWork unitOfWork) : base(unitOfWork) { }

    }
}

using Monitoring_App.Domain.BaseArchitecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services
{
    public interface IServicesRepository : IRepository<Service>
    {
    }
}

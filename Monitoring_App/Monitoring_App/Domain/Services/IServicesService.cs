using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services
{
    public interface IServicesService
    {
        List<Service> GetAll();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services
{
    public interface IServicesService
    {
        List<Service> GetAll();
        Task Create(Service service);
        Task CreateMultiple(List<Service> entity);
        Task Delete(int id);
        Task Edit(Service service);
        Task<Service> GetById(int id);
    }
}

using Monitoring_App.Domain.BaseArchitecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services
{
    public class ServicesService : IServicesService
    {
        private readonly IServicesRepository _servicesRepository;

        public ServicesService(IServicesRepository servicesRepository)
        {
            _servicesRepository = servicesRepository;
        }

        public List<Service> GetAll()
        {
            return _servicesRepository.GetAll().ToList();
        }
    }
}

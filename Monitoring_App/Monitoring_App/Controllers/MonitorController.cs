using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring_App.Domain.Requests;
using Monitoring_App.Domain.Services;

namespace Monitoring_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonitorController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IServicesService _servicesService;

        public MonitorController(ApplicationContext context, IServicesService servicesService)
        {
            _context = context;
            _servicesService = servicesService;
        }

        [HttpGet]
        public List<ServiceViewModel> GetServicesState()
        {
            List<Service> services = _servicesService.GetAll();
            List<ServiceViewModel> serviceViewModels = RequestService.GetStatus(services);
            
            return serviceViewModels;
        }
    }
}
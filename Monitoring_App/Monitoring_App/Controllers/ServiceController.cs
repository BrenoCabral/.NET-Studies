using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monitoring_App.Domain.Services;

namespace Monitoring_App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : Controller
    {
        private readonly IServicesService _servicesService;

        public ServiceController(IServicesService servicesService)
        {
            _servicesService = servicesService;
        }
        [HttpGet]
        [Route("GetAll")]
        public List<Service> GetAll()
        {
            return _servicesService.GetAll();
        }
        
        // GET: Service/Create
        [HttpPost]
        [Route("CreateService")]
        public async Task<ActionResult> CreateAsync([FromBody]Service service)
        {
            try
            {
                await _servicesService.Create(service);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("\nThere was a problem while attempting to save the service. Error: " + e.Message);
            }

        }

        // POST: Service/Create
        [HttpPost]
        [Route("CreateListOfService")]
        public async Task<ActionResult> CreateAsync(List<Service> services)
        {
            try
            {
                await _servicesService.CreateMultiple(services);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("An error occurred when creating multiple services. Error: " + e.Message);
            }
        }

        // GET: Service/Edit/5
        [HttpGet]
        [Route("GetById/{id}")]
        public async Task<Service> GetById(int id)
        {
            Service service = await _servicesService.GetById(id);
            return service;
        }
        [HttpPost]
        [Route("Edit")]
        public ActionResult Edit([FromBody]Service service)
        {
            _servicesService.Edit(service);
            return Ok();
        }

        [Route("Delete/{id}")]
        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            _servicesService.Delete(id);
            return Ok();
        }

    }
}
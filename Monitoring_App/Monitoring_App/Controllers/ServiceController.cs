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
        public List<Service> GetAll()
        {
            return _servicesService.GetAll();
        }

        // GET: Service/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Service/Create
        [HttpPost]
        public async Task<ActionResult> CreateAsync(Service service)
        {
            try
            {
                await _servicesService.Create(service);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("\nThere was a problema while attempting to save the service. Error: " + e.Message);
            }

        }

        // POST: Service/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(List<Service> services)
        {
            List<string> servicesWithError = new List<string>();
            try
            {
                await Task.Run(
                    () =>
                    {
                        foreach (var service in services)
                        {
                            if (!CreateAsync(service).IsCompletedSuccessfully)
                            {
                                servicesWithError.Add(service.Name);
                            }
                        }
                        if (servicesWithError.Any()) throw new Exception();
                    }
                );
                return Ok();
            }
            catch
            {
                string errorsList = string.Join(',', servicesWithError);
                return BadRequest("The following services could not be created: " + errorsList);
            }
        }

        // GET: Service/Edit/5
        public ActionResult Edit(Service service)
        {
            _servicesService.Edit(service);
            return View();
        }

        // GET: Service/Delete/5
        public ActionResult Delete(int id)
        {
            _servicesService.Delete(id);
            return View();
        }

    }
}
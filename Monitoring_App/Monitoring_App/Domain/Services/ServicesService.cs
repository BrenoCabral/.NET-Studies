using Monitoring_App.Domain.BaseArchitecture;
using Monitoring_App.Domain.Enums;
using Monitoring_App.Domain.Factories;
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

        public async Task Create(Service service)
        {
            try
            {
                ValidateService(service);
                await _servicesRepository.Create(service);
            }
            catch (Exception e)
            {
                throw new Exception($"There was a problem while creating the service {service.Name}. {e.Message}");
            }
            
        }

        private void ValidateService(Service service)
        {
            try
            {
                ValidateType(service.TypeDescription);
                ValidateEnviromment(service.Enviromment);
                ValidateCompanyCell(service.CompanyCell);
            }
            catch(Exception e)
            {
                throw new Exception($"There was a problem while creating the service {service.Name}. {e.Message}");
            }
            
        }

        private void ValidateCompanyCell(string companyCell)
        {
            try
            {
                AuxiliaryMethods.GetEnumFromString<CompanyCellEnum>(companyCell);
            }
            catch
            {
                throw new Exception("The Company Cell is not valid.");
            }
        }

        private void ValidateEnviromment(string enviromment)
        {
            try{
                AuxiliaryMethods.GetEnumFromString<EnvirommentEnum>(enviromment);
            }
            catch
            {
                throw new Exception("The Enviromment is not valid.");
            }

        }

        private void ValidateType(string typeDescription)
        {
            try
            {
                ServiceTypeFactory.Create(typeDescription);
            }
            catch
            {
                throw new Exception("The typeDescription is not valid.");
            }
        }

        public async Task CreateMultiple(List<Service> services)
        {
            foreach (var service in services)   
            {
                ValidateService(service);
            }
            await _servicesRepository.CreateMultiple(services);
        }
        public async Task Delete(int id)
        {
            await _servicesRepository.Delete(id);
        }
        public async Task Edit(Service service)
        {
            await _servicesRepository.Update(service);
        }

        public async Task<Service> GetById(int id)
        {
            return await _servicesRepository.GetById(id);
        }
    }
}

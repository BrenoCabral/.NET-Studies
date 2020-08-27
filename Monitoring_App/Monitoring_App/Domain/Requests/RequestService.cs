using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Monitoring_App.Domain.Factories;
using Monitoring_App.Domain.Services;
using Monitoring_App.Domain.States;

namespace Monitoring_App.Domain.Requests
{
    public class RequestService
    {
        internal static List<ServiceViewModel> GetStatus(List<Service> services)
        {
            List<ServiceViewModel> serviceViewModels = new List<ServiceViewModel>();
            foreach (var service in services)
            {
                ServiceViewModel serviceViewModel = new ServiceViewModel();
                IState serviceState = ServiceTypeFactory.Create(service.TypeDescription).GetState(service.CommunicationEndpoint, service.VersionEndpoint);
                serviceViewModel = service;
                serviceViewModel.State = (State)serviceState;
                serviceViewModels.Add(serviceViewModel);
            }

            return serviceViewModels;
        }
    }
}

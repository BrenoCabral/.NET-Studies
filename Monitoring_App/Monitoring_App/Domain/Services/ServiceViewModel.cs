using Monitoring_App.Domain.Enums;
using Monitoring_App.Domain.Factories;
using Monitoring_App.Domain.Services.Types;
using Monitoring_App.Domain.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Monitoring_App.Domain.Services
{
    public class ServiceViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TypeDescription { get; set; }
        public string VersionEndpoint { get; set; }
        public string CommunicationEndpoint { get; set; }
        public EnvirommentEnum Enviromment { get; set; }
        public CompanyCellEnum CompanyCell { get; set; }
        public string Cloud { get; set; }
        public IState State { get; set; }

        public static implicit operator ServiceViewModel(Service service)
        {
            ServiceViewModel serviceViewModel = new ServiceViewModel();
            serviceViewModel.Id = service.Id;
            serviceViewModel.Name = service.Name;
            serviceViewModel.Description = service.Description;
            serviceViewModel.TypeDescription = service.TypeDescription;
            serviceViewModel.VersionEndpoint = service.VersionEndpoint;
            serviceViewModel.CommunicationEndpoint = service.CommunicationEndpoint;
            serviceViewModel.Enviromment = GetEnumFromString<EnvirommentEnum>(service.Enviromment);
            serviceViewModel.CompanyCell = GetEnumFromString<CompanyCellEnum>(service.CompanyCell);
            serviceViewModel.Cloud = service.Cloud;

            return serviceViewModel;
        }

        private static T GetEnumFromString<T>(string enumString)
        {
            try
            {
                T myEnum = (T)Enum.Parse(typeof(T), enumString);
                return myEnum;
            }catch(Exception e)
            {
                Console.WriteLine("An error acurred when converting string to ENUM. Error:" + e.Message);
                throw e;
            }
            
        }
    }
}

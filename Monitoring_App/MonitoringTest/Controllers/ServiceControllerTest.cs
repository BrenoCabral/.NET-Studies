//using Microsoft.AspNetCore.TestHost;
//using Monitoring_App;
//using Monitoring_App.Controllers;
//using Monitoring_App.Domain.Services;
//using Newtonsoft.Json;
//using NUnit.Framework;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;

//namespace MonitoringTest.Controllers
//{
//    class ServiceControllerTest
//    {
//        private APIWebApplicationFactory _factory;
//        private HttpClient _client;
//        private Service service;

//        [SetUp]
//        public void Setup()
//        {
//            _factory = new APIWebApplicationFactory();
//            _client = _factory.WithWebHostBuilder(builder => builder.UseSolutionRelativeContentRoot("Controllers/ServiceController")).CreateClient();
//            service = new Service()
//            {
//                Name="MaxPedidoApi",
//                Cloud="Aws",
//                CommunicationEndpoint= "Testing End point",
//                CompanyCell = "Max Pedidos",
//                Description = "É o max pedidos",
//                Enviromment = "Homlog",
//                TypeDescription = "API",
//                VersionEndpoint = "Version"
                
//            };
//        }

//        [Test]
//        public async Task GetAllRight()
//        {
//            List<Service> servicesList = await GetAllServices();

//            Assert.IsTrue(servicesList.Any());

//        }

//        private async Task<List<Service>> GetAllServices()
//        {
//            var result = await _client.GetAsync("GetAll");
//            Assert.IsTrue(result.IsSuccessStatusCode);
//            var resultString = await result.Content.ReadAsStringAsync();
//            var servicesList = JsonConvert.DeserializeObject<List<Service>>(resultString);
//            return servicesList;
//        }

//        [Test]
//        public async Task CreateServiceRight()
//        {
//            var servicesNumber = GetAllServices().Result.Count();
//            var data = JsonConvert.SerializeObject(service);
//            var content = new StringContent(data, Encoding.UTF8, "application/json");
//            var result = await _client.PostAsync("CreateAsync", content);
//            Assert.IsTrue(result.IsSuccessStatusCode);
//            Assert.AreEqual(servicesNumber + 1, GetAllServices().Result.Count());
            

//        }

//    }
//}

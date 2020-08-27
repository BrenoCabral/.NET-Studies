using Monitoring_App;
using Monitoring_App.Domain.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Api.IntegrationTests;
using Xunit;

namespace MonitoringIntegrationTest.ControllersTest
{
    public class ServiceControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public ServiceControllerTest(CustomWebApplicationFactory<Startup> factory)
        {
            _client = factory.CreateClient();
        }
        [Fact]
        public async Task CanGetAllServices()
        {
            // The endpoint or route of the controller action.
            IEnumerable<Service> services = await GetAllServices();
            Assert.Contains(services, s => s.Name == "MaxPedidoApi");
        }

        private async Task<IEnumerable<Service>> GetAllServices()
        {
            var httpResponse = await _client.GetAsync("/api/service/GetAll");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<IEnumerable<Service>>(stringResponse);
            return services;
        }

        [Fact]
        public async Task CanGetServiceById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/service/GetById/1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var service = JsonConvert.DeserializeObject<Service>(stringResponse);
            Assert.Equal(1, service.Id);
            Assert.Equal("MaxPedidoApi", service.Name);
        }
        [Fact]
        public async Task CanCreateService()
        {
            Service service = new Service()
            {
                Name = "PostgreSQL",
                Cloud = "Aws",
                CommunicationEndpoint = "http://serverpdvv.solucoesmaxima.com.br:8081/swagger",
                CompanyCell = "Max Pedidos",
                Description = "É o max pedidos",
                Enviromment = "Production",
                TypeDescription = "API",
                VersionEndpoint = "Version"

            };

            var data = JsonConvert.SerializeObject(service);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync("/api/service/CreateService", content);

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var servicesResult = (List<Service>)await GetAllServices();
            Assert.Equal("PostgreSQL", servicesResult[servicesResult.Count - 1].Name);
        }
        [Fact]
        public async Task CanCreateListOfService()
        {
            var servicesCount = ((List<Service>)await GetAllServices()).Count;
            List<Service> listService = new List<Service>()
            {
                new Service()
            {
                Name = "PostgreSQL",
                Cloud = "Aws",
                CommunicationEndpoint = "http://serverpdvv.solucoesmaxima.com.br:8081/swagger",
                CompanyCell = "Max Pedidos",
                Description = "É o max pedidos",
                Enviromment = "Homlog",
                TypeDescription = "API",
                VersionEndpoint = "Version"

            },
                new Service() {
                Name = "Oracle",
                Cloud = "Aws",
                CommunicationEndpoint = "http://serverpdvv.solucoesmaxima.com.br:8081/swagger",
                CompanyCell = "Max Pedidos",
                Description = "É o max pedidos",
                Enviromment = "Homlog",
                TypeDescription = "API",
                VersionEndpoint = "Version"

            }
            };

            var data = JsonConvert.SerializeObject(listService);
            var content = new StringContent(data, Encoding.UTF8, "application/json");
            var httpResponse = await _client.PostAsync("/api/service/CreateListOfService", content);

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var servicesResult = (List<Service>)await GetAllServices();
            Assert.Equal(servicesCount+2, servicesResult.Count);
        }
    }
}

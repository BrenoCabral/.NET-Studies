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
    public class MonitoringControllerTest : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        private readonly HttpClient _client;

        public MonitoringControllerTest(CustomWebApplicationFactory<Startup> factory)
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
            var httpResponse = await _client.GetAsync("/api/monitor/GetServicesStates");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var services = JsonConvert.DeserializeObject<IEnumerable<Service>>(stringResponse);
            return services;
        }
    }
}

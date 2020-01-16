﻿using Monitoring_App;
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
        public async Task CanGetPlayers()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/players");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var players = JsonConvert.DeserializeObject<IEnumerable<Player>>(stringResponse);
            Assert.Contains(players, p => p.FirstName == "Wayne");
            Assert.Contains(players, p => p.FirstName == "Mario");
        }


        [Fact]
        public async Task CanGetPlayerById()
        {
            // The endpoint or route of the controller action.
            var httpResponse = await _client.GetAsync("/api/players/1");

            // Must be successful.
            httpResponse.EnsureSuccessStatusCode();

            // Deserialize and examine results.
            var stringResponse = await httpResponse.Content.ReadAsStringAsync();
            var player = JsonConvert.DeserializeObject<Player>(stringResponse);
            Assert.Equal(1, player.Id);
            Assert.Equal("Wayne", player.FirstName);
        }
    }
}
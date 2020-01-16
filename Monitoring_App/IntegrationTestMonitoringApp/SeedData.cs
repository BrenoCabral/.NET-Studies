
using Monitoring_App;
using Monitoring_App.Domain.Services;
using System;

namespace Web.Api.IntegrationTests
{
    public static class SeedData
    {
        public static void PopulateTestData(ApplicationContext dbContext)
        {
            dbContext.Services.Add(new Service() {
                Name = "MaxPedidoApi",
                Cloud = "Aws",
                CommunicationEndpoint = "Testing End point",
                CompanyCell = "Max Pedidos",
                Description = "É o max pedidos",
                Enviromment = "Homlog",
                TypeDescription = "API",
                VersionEndpoint = "Version"
            });
            
            dbContext.SaveChanges();
        }
    }
}
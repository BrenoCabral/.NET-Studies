using Microsoft.EntityFrameworkCore;
using Monitoring_App.Domain.Services;

namespace Monitoring_App
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
                : base(options)
        {
        }

        public DbSet<Service> Services { get; set; }
    }
}
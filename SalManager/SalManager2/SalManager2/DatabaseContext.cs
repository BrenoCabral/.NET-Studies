using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SalManager2.Domain.Models;

namespace SalManager2
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {

        }
        protected internal virtual void OnModelCreating(Microsoft.EntityFrameworkCore.ModelBuilder modelBuilder)
        {

        }

        public DbSet<Membro> Membros { get; set; }
        public DbSet<PG> PGs { get; set; }
    }
}

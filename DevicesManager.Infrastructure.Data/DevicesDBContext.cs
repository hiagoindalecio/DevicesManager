using DevicesManager.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DevicesManager.Infrastructure.Data
{
    public class DevicesDBContext : DbContext
    {
        public DevicesDBContext() { }

        public DevicesDBContext(DbContextOptions<DevicesDBContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // For tests running
            {
                var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.test.json")
                    .Build();
                optionsBuilder.UseNpgsql(config.GetConnectionString("DevicesDBContext"));
            }
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("CreationDate") != null))
            {
                if (entry.State == EntityState.Added)
                    entry.Property("CreationDate").CurrentValue = DateTime.UtcNow;
                else if (entry.State == EntityState.Modified)
                    entry.Property("CreationDate").IsModified = false;
            }

            return base.SaveChanges();
        }
    }
}

using DevicesManager.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DevicesManager.Infrastructure.Data
{
    public class DevicesDBContext : DbContext
    {
        public DevicesDBContext() { }

        public DevicesDBContext(DbContextOptions<DevicesDBContext> options) : base(options) { }

        public DbSet<Device> Devices { get; set; }

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

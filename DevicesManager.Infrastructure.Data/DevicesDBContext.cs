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
            => base.SaveChanges();
    }
}

using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Models;
using DevicesManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace DevicesManager.Infrastruture.Repository.Repositories
{
    public class DeviceRepository(DevicesDBContext context) : BaseRepository<Device>(context), IDeviceRepository
    {
        private readonly DevicesDBContext _context = context;

        public IEnumerable<Device> GetByBrand(string brandName)
            => _context.Set<Device>().AsNoTracking().Where(x => x.Brand.ToUpper().Contains(brandName.ToUpper()));
    }
}

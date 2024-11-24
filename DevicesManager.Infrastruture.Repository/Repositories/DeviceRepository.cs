using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Models;
using DevicesManager.Infrastructure.Data;

namespace DevicesManager.Infrastruture.Repository.Repositories
{
    public class DeviceRepository : BaseRepository<Device>, IDeviceRepository
    {
        private readonly DevicesDBContext _context;

        public DeviceRepository(DevicesDBContext context)
            : base(context)
        {
            _context = context;
        }

        public IEnumerable<Device> GetByBrad(string brandName)
        {
            return _context.Set<Device>().Where(x => x.Brand == brandName);
        }
    }
}

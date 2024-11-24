using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Core.Interfaces.Services;
using DevicesManager.Domain.Models;

namespace DevicesManager.Domain.Services.Services
{
    public class DeviceService : BaseService<Device>, IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository;

        public DeviceService(IDeviceRepository deviceRepository)
            : base(deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        public IEnumerable<Device> GetByBrad(string brandName)
        {
            return _deviceRepository.GetByBrad(brandName);
        }
    }
}

using DevicesManager.Domain.Core.Interfaces.Repositories;
using DevicesManager.Domain.Core.Interfaces.Services;
using DevicesManager.Domain.Models;

namespace DevicesManager.Domain.Services.Services
{
    public class DeviceService(IDeviceRepository deviceRepository) : BaseService<Device>(deviceRepository), IDeviceService
    {
        private readonly IDeviceRepository _deviceRepository = deviceRepository;

        public IEnumerable<Device> GetByBrand(string brandName)
            => _deviceRepository.GetByBrand(brandName);
    }
}

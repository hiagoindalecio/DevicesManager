using DevicesManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using DevicesManager.Application.DTO.DTO;
using DevicesManager.Application.Interfaces;
using DevicesManager.Domain.Core.Interfaces.Services;

namespace DevicesManager.Application.Services
{
    public class ApplicationServiceDevice : IApplicationServiceDevice
    {
        private readonly IDeviceService _deviceService;
        private readonly IDeviceMapper _deviceMapper;

        public ApplicationServiceDevice(IDeviceService deviceService, IDeviceMapper deviceMapper)
        {
            _deviceService = deviceService;
            _deviceMapper = deviceMapper;
        }

        public void Add(DeviceDTO obj)
        {
            var deviceObj = _deviceMapper.MapperToEntity(obj);
            _deviceService.Add(deviceObj);
        }

        public DeviceDTO GetById(int id)
        {
            var deviceObj = _deviceService.GetById(id);
            return _deviceMapper.MapperToDTO(deviceObj);
        }

        public IEnumerable<DeviceDTO> GetAll()
        {
            var deviceObjs = _deviceService.GetAll();
            return _deviceMapper.MapperListOfDevices(deviceObjs);
        }

        public IEnumerable<DeviceDTO> GetByBrad(string brandName)
        {
            var deviceObjs = _deviceService.GetByBrad(brandName);
            return _deviceMapper.MapperListOfDevices(deviceObjs);
        }

        public void Update(DeviceDTO obj)
        {
            var deviceObj = _deviceMapper.MapperToEntity(obj);
            _deviceService.Update(deviceObj);
        }

        public void Delete(DeviceDTO obj)
        {
            var deviceObj = _deviceMapper.MapperToEntity(obj);
            _deviceService.Delete(deviceObj);
        }

        public void Dispose()
        {
            _deviceService.Dispose();
        }
    }
}

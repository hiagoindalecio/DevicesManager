using DevicesManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using DevicesManager.Application.DTO.DTO;
using DevicesManager.Application.Interfaces;
using DevicesManager.Domain.Core.Interfaces.Services;

namespace DevicesManager.Application.Services
{
    public class DeviceApplicationService(IDeviceService deviceService, IDeviceMapper deviceMapper) : IDeviceApplicationService
    {
        private readonly IDeviceService _deviceService = deviceService;
        private readonly IDeviceMapper _deviceMapper = deviceMapper;

        public void Add(DeviceCreationDTO obj, out string Error)
        {
            Error = string.Empty;
            try
            {
                var deviceObj = _deviceMapper.MapperToEntity(obj);
                _deviceService.Add(deviceObj);
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong during device creation. {ex.Message}";
            }
        }

        public DeviceDTO? GetById(int id, out string Error)
        {
            Error = string.Empty;
            try
            {
                var deviceObj = _deviceService.GetById(id);
                return deviceObj != null ? _deviceMapper.MapperToDTO(deviceObj) : null;
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong while searching for the device by identifier. {ex.Message}";
            }
            return null;
        }

        public IEnumerable<DeviceDTO>? GetAll(out string Error)
        {
            Error = string.Empty;
            try
            {
                var deviceObjs = _deviceService.GetAll();
                return _deviceMapper.MapperListOfDevices(deviceObjs);
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong while searching for devices. {ex.Message}";
            }
            return null;
        }

        public IEnumerable<DeviceDTO>? GetByBrand(string brandName, out string Error)
        {
            Error = string.Empty;
            try
            {
                var deviceObjs = _deviceService.GetByBrand(brandName);
                return _deviceMapper.MapperListOfDevices(deviceObjs);
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong while searching for the device by brand. {ex.Message}";
            }
            return null;
        }

        public void Update(DeviceDTO obj, out string Error)
        {
            Error = string.Empty;
            try
            {
                var deviceObj = _deviceMapper.MapperToEntity(obj);
                _deviceService.Update(deviceObj);
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong while updating the device. {ex.Message}";
            }
        }

        public void Delete(int id, out string Error)
        {
            Error = string.Empty;
            try
            {
                _deviceService.Delete(id);
            }
            catch (Exception ex)
            {
                Error = $"Something went wrong while deleting the device. {ex.Message}";
            }
        }

        public void Dispose()
        {
            _deviceService.Dispose();
        }
    }
}

using DevicesManager.Infrastruture.CrossCutting.Adapter.Interfaces;
using DevicesManager.Application.DTO.DTO;
using DevicesManager.Domain.Models;

namespace DevicesManager.Infrastruture.CrossCutting.Adapter.Maps
{
    internal class DeviceMapper : IDeviceMapper
    {
        public IEnumerable<DeviceDTO> MapperListOfDevices(IEnumerable<Device> devices)
        {
            List<DeviceDTO> devicesDTOs = [];

            foreach (var item in devices)
            {
                DeviceDTO deviceDTO = new()
                {
                    Id = item.Id,
                    Name = item.Name,
                    Brand = item.Brand,
                    CreationDate = item.CreationDate
                };

                devicesDTOs.Add(deviceDTO);
            }

            return devicesDTOs;
        }

        public DeviceDTO MapperToDTO(Device device)
            => new()
            {
                Id = device.Id,
                Name = device.Name,
                Brand = device.Brand,
                CreationDate = device.CreationDate
            };

        public Device MapperToEntity(DeviceDTO deviceDTO)
            => new()
            {
                Id = deviceDTO.Id,
                Name = deviceDTO.Name,
                Brand = deviceDTO.Brand,
                CreationDate = deviceDTO.CreationDate
            };
    }
}

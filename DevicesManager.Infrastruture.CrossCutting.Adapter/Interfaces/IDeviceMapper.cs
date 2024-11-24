using DevicesManager.Application.DTO.DTO;
using DevicesManager.Domain.Models;

namespace DevicesManager.Infrastruture.CrossCutting.Adapter.Interfaces
{
    /// <summary>
    /// Device mapper
    /// </summary>
    public interface IDeviceMapper
    {
        /// <summary>
        /// Map the device data transfer object to an entity
        /// </summary>
        /// <param name="deviceDTO">Device data transfer object</param>
        /// <returns>Device entity</returns>
        Device MapperToEntity(DeviceDTO deviceDTO);

        /// <summary>
        /// Map a list of devices to a list of data transfer objects
        /// </summary>
        /// <param name="devices">Device entity</param>
        /// <returns>List of device data transfer objects</returns>
        IEnumerable<DeviceDTO> MapperListOfDevices(IEnumerable<Device> devices);

        /// <summary>
        /// Map a device to a data transfer objects
        /// </summary>
        /// <param name="device">Device entity</param>
        /// <returns>Device data transfer object</returns>
        DeviceDTO MapperToDTO(Device device);
    }
}

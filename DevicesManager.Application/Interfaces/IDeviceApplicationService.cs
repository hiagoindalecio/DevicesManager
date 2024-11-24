using DevicesManager.Application.DTO.DTO;

namespace DevicesManager.Application.Interfaces
{
    /// <summary>
    /// Application service to manage devices
    /// </summary>
    public interface IDeviceApplicationService
    {
        /// <summary>
        /// Add a new device to the database
        /// </summary>
        /// <param name="obj">Device to add</param>
        void Add(DeviceDTO obj);

        /// <summary>
        /// Get device by the identifier
        /// </summary>
        /// <param name="id">Device identifier</param>
        /// <returns>Device (if found)</returns>
        DeviceDTO GetById(int id);

        /// <summary>
        /// Get all entities from the database
        /// </summary>
        /// <returns>A list of entities</returns>
        IEnumerable<DeviceDTO> GetAll();

        /// <summary>
        /// Get devices by the brand name
        /// </summary>
        /// <param name="brandName">Device brand name</param>
        /// <returns>List of found devices</returns>
        IEnumerable<DeviceDTO> GetByBrad(string brandName);

        /// <summary>
        /// Update the device properties on database
        /// </summary>
        /// <param name="obj">Device new properties</param>
        void Update(DeviceDTO obj);

        /// <summary>
        /// Delete an device from the database
        /// </summary>
        /// <param name="obj">Device to delete</param>
        void Delete(DeviceDTO obj);

        /// <summary>
        /// Dispose the device context changes
        /// </summary>
        void Dispose();
    }
}

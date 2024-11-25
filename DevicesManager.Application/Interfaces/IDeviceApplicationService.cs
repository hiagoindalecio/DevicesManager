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
        /// <param name="Error">Error message, if happens</param>
        void Add(DeviceCreationDTO obj, out string Error);

        /// <summary>
        /// Get device by the identifier
        /// </summary>
        /// <param name="id">Device identifier</param>
        /// <param name="Error">Error message, if happens</param>
        /// <returns>Device (if found)</returns>
        DeviceDTO? GetById(int id, out string Error);

        /// <summary>
        /// Get all entities from the database
        /// </summary>
        /// <param name="Error">Error message, if happens</param>
        /// <returns>A list of entities</returns>
        IEnumerable<DeviceDTO>? GetAll(out string Error);

        /// <summary>
        /// Get devices by the brand name
        /// </summary>
        /// <param name="brandName">Device brand name</param>
        /// <param name="Error">Error message, if happens</param>
        /// <returns>List of found devices</returns>
        IEnumerable<DeviceDTO>? GetByBrand(string brandName, out string Error);

        /// <summary>
        /// Update the device properties on database
        /// </summary>
        /// <param name="obj">Device new properties</param>
        /// <param name="Error">Error message, if happens</param>
        void Update(DeviceDTO obj, out string Error);

        /// <summary>
        /// Delete an device from the database
        /// </summary>
        /// <param name="id">Device identifier</param>
        /// <param name="Error">Error message, if happens</param>
        void Delete(int id, out string Error);

        /// <summary>
        /// Dispose the device context changes
        /// </summary>
        void Dispose();
    }
}

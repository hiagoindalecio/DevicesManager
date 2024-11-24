using DevicesManager.Domain.Models;

namespace DevicesManager.Domain.Core.Interfaces.Services
{
    /// <summary>
    /// Device service
    /// </summary>
    public interface IDeviceService : IBaseService<Device>
    {
        /// <summary>
        /// Get devices by the brand name
        /// </summary>
        /// <param name="brandName">Device brand name</param>
        /// <returns>List of found devices</returns>
        IEnumerable<Device> GetByBrad(string brandName);
    }
}

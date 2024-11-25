using DevicesManager.Domain.Models;

namespace DevicesManager.Domain.Core.Interfaces.Repositories
{
    /// <summary>
    /// Device repository
    /// </summary>
    public interface IDeviceRepository : IBaseRepository<Device>
    {
        /// <summary>
        /// Get devices by the brand name
        /// </summary>
        /// <param name="brandName">Device brand name</param>
        /// <returns>List of found devices</returns>
        IEnumerable<Device> GetByBrand(string brandName);
    }
}

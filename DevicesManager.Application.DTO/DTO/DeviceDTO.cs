namespace DevicesManager.Application.DTO.DTO
{
    /// <summary>
    /// Devices data transfer object
    /// </summary>
    public class DeviceDTO
    {
        /// <summary>
        /// The device identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The device name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The device brand name
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// The device creation date and time
        /// </summary>
        public DateTime CreationDate { get; set; }

        /// <summary>
        /// Devices data transfer object constructor
        /// </summary>
        public DeviceDTO(int id, string name, string brand, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Brand = brand;
            CreationDate = creationDate;
        }

        public DeviceDTO()
        {
            Name = string.Empty;
            Brand = string.Empty;
        }
    }
}

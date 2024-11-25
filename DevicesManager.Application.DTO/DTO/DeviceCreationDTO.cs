namespace DevicesManager.Application.DTO.DTO
{
    public class DeviceCreationDTO
    {
        /// <summary>
        /// The device name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The device brand name
        /// </summary>
        public string Brand { get; set; }

        public DeviceCreationDTO(string name, string brand)
        {
            Name = name;
            Brand = brand;
        }
    }
}

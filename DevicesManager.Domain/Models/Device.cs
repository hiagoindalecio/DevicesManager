namespace DevicesManager.Domain.Models
{
    /// <summary>
    /// Model to implement the device properties
    /// </summary>
    public class Device : Base
    {
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

        public Device(int id, string name, string brand, DateTime creationDate)
        {
            Id = id;
            Name = name;
            Brand = brand;
            CreationDate = creationDate;
        }

        public Device()
        {
            Name = string.Empty;
            Brand = string.Empty;
        }
    }
}

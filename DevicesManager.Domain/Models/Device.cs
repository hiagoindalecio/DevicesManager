using System.ComponentModel.DataAnnotations.Schema;

namespace DevicesManager.Domain.Models
{
    /// <summary>
    /// Model to implement the device properties
    /// </summary>
    [Table("devices")]
    public class Device : Base
    {
        /// <summary>
        /// The device name
        /// </summary>
        [Column("name")]
        public string Name { get; set; }

        /// <summary>
        /// The device brand name
        /// </summary>
        [Column("brand")]
        public string Brand { get; set; }

        /// <summary>
        /// The device creation date and time
        /// </summary>
        [Column("creation_date")]
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

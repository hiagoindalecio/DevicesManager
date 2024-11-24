using System.ComponentModel.DataAnnotations.Schema;

namespace DevicesManager.Domain.Models
{
    /// <summary>
    /// Base model
    /// </summary>
    public class Base
    {
        /// <summary>
        /// The entity identifier
        /// </summary>
        [Column("id")]
        public int Id { get; set; }
    }
}

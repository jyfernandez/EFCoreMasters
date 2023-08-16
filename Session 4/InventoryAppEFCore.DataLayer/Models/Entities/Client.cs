using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.Models.Entities
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }
        public Order Order { get; set; }

    }
}

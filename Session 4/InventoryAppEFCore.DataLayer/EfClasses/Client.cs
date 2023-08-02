using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        public bool IsDeleted { get; set; }

    }
}

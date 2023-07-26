using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        [MaxLength(50)]
        [Required]
        public string VoterName { get; set; }

        private string _comment;

        public string Comment => _comment;
        public int NumStars { get; set; }

        public int ProductId { get; set; }
    }
}

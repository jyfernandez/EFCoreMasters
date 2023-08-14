using InventoryAppEFCore.DataLayer.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class ReviewDTO
    {
        public int ReviewId { get; set; }
        public string VoterName { get; set; }
        public string Comment { get; set; }
        public int NumStars { get; set; }
        public int ProductId { get; set; }
    }
}

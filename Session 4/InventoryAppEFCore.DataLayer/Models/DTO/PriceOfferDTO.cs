namespace InventoryAppEFCore.DataLayer.Models.DTO
{
    public class PriceOfferDTO
    {
        public int PriceOfferId { get; set; }
        public decimal NewPrice { get; set; }
        public string PromotinalText { get; set; }
        public int ProductId { get; set; }
    }
}

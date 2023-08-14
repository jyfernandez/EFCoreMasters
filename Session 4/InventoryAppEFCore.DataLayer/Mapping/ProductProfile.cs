using AutoMapper;
using InventoryAppEFCore.DataLayer.Models.DTO;
using InventoryAppEFCore.DataLayer.Models.Entities;

namespace InventoryAppEFCore.DataLayer.Mapping
{
    public class ProductProfile: Profile
    {
        public ProductProfile()
        {
            CreateMap<LineItem, LineItemDTO>()
                .ForMember(l => l.SelectedProduct, s => s.MapFrom(x => x.SelectedProduct))
                .ForMember(l => l.LineItemId, s => s.MapFrom(x => x.LineItemId));
 
            CreateMap<PriceOffer, PriceOfferDTO>()
                .ForMember(p => p.PriceOfferId, s => s.MapFrom(x => x.PriceOfferId));

            CreateMap<Product, ProductDTO>()
             .ForMember(p => p.ProductId, s => s.MapFrom(x => x.ProductId));

            CreateMap<ProductSupplier, ProductSupplierDTO>();

            CreateMap<Review, ReviewDTO>()
                .ForMember(r => r.ReviewId, s => s.MapFrom(x => x.ReviewId));

            CreateMap<Supplier, SupplierDTO>()
                .ForMember(s => s.SupplierId, s => s.MapFrom(x => x.SupplierId));

            CreateMap<Tag, TagDTO>()
                .ForMember(t => t.TagId, s => s.MapFrom(x => x.TagId));
        }
    }
}

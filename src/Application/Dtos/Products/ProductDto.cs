using Application.Common.Mapping;
using Application.Common.Mapping.Resolver;
using Application.Dtos.Common;
using AutoMapper;
using Domain.Entities;

namespace Application.Dtos.Products
{
    public class ProductDto : CommandDto, IMapFrom<Product>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public int ProductTypeId { get; set; }
        public int ProductBrandId { get; set; }
        public string ProductType { get; set; }   // Title
        public string ProductBrand { get; set; }  // Title

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Product, ProductDto>()
                .ForMember(p => p.ProductType, c => c.MapFrom(m => m.ProductType.Title))
                .ForMember(p => p.ProductBrand, c => c.MapFrom(m => m.ProductBrand.Title))
                .ForMember(p => p.ImageUrl, c => c.MapFrom<ProductImageUrlResolver>());
        }
    }
}

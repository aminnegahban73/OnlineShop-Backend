using Application.Dtos.Products;
using AutoMapper;
using Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Application.Common.Mapping.Resolver
{
    public class ProductImageUrlResolver : IValueResolver<Product, ProductDto, string>
    {
        private readonly IConfiguration _configuration;

        public ProductImageUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string Resolve(Product source, ProductDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrWhiteSpace(source.ImageUrl))
            {
                return _configuration["ApiUrl"] + _configuration["ImagesLocation:ProductImageLocation"] + source.ImageUrl;
            }
            return null;
        }
    }
}

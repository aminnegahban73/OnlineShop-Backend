using Application.Contract;
using Application.Dtos.Products;
using Application.Wrappers;
using MediatR;
using Newtonsoft.Json;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQuery : RequestParametersBasic, IRequest<IEnumerable<ProductDto>>, ICacheQuery
    {
        public int PageId { get; set; }
        public int? TypeId { get; set; }
        public int? BrandId { get; set; }

        [JsonIgnore]
        public int HourSaveData => 1;
    }
}

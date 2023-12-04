using Domain.Entities;
using MediatR;

namespace Application.Features.ProductBrands.Queries.GetAll
{
    public class GetAllProductBrandsQuery : IRequest<IEnumerable<ProductBrand>>
    {

    }
}

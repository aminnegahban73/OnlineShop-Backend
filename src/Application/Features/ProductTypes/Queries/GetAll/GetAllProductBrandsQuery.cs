using Domain.Entities;
using MediatR;

namespace Application.Features.ProductTypes.Queries.GetAll
{
    public class GetAllProductTypesQuery : IRequest<IEnumerable<ProductType>>
    {

    }
}

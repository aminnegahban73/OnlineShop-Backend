using Application.Dtos.Products;
using MediatR;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
    {

    }
}

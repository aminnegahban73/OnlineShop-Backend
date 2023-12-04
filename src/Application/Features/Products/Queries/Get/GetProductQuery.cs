using Domain.Entities;
using MediatR;

namespace Application.Features.Products.Queries.Get
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
        public GetProductQuery(int Id)
        {
            this.Id = Id;   
        }
    }
}

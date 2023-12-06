using Application.Contract.Specification;
using Domain.Entities;

namespace Application.Features.Products.Queries.Get
{
    public class GetProductSpec : BaseSpecification<Product>
    {
        public GetProductSpec(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}

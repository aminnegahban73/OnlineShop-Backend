using Application.Contract.Specification;
using Domain.Entities;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsSpec : BaseSpecification<Product>
    {
        public GetAllProductsSpec() : base()
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }
    }
}

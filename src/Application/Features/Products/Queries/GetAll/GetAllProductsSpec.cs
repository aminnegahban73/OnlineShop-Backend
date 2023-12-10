using Application.Contract.Specification;
using Application.Wrappers;
using Domain.Entities;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsSpec : BaseSpecification<Product>
    {
        public GetAllProductsSpec(GetAllProductsQuery request) : base(c =>
            (!request.BrandId.HasValue || c.ProductBrandId == request.BrandId) &&
            (!request.TypeId.HasValue || c.ProductTypeId == request.TypeId))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            if (request.TypeSort == TypeSort.Desc)
            {
                switch (request.Sort)
                {
                    case 1:
                        AddOrderBy(c => c.Id);
                        break;
                    case 2:
                        AddOrderBy(c => c.Title);
                        break;
                    default:
                        AddOrderBy(c => c.Id);
                        break;
                }
            }
            else
            {
                switch (request.Sort)
                {
                    case 1:
                        AddOrderByDesc(c => c.Id);
                        break;
                    case 2:
                        AddOrderByDesc(c => c.Title);
                        break;
                    default:
                        AddOrderByDesc(c => c.Id);
                        break;
                }
            }
        }
    }
}

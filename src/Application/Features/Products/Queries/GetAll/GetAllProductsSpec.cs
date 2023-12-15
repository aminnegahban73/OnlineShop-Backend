using Application.Contract.Specification;
using Application.Wrappers;
using Domain.Entities;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsSpec : BaseSpecification<Product>
    {
        public GetAllProductsSpec(GetAllProductsQuery specParams) : base(c =>
            (!specParams.BrandId.HasValue || c.ProductBrandId == specParams.BrandId) &&
            (!specParams.TypeId.HasValue || c.ProductTypeId == specParams.TypeId))
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            if (specParams.TypeSort == TypeSort.Desc)
            {
                switch (specParams.Sort)
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
                switch (specParams.Sort)
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

            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize, true);
        }
    }
}

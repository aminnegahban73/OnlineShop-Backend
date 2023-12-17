using Application.Contract.Specification;
using Application.Wrappers;
using Domain.Entities;
using System.Linq.Expressions;

namespace Application.Features.Products.Queries.GetAll
{
    public class GetAllProductsSpec : BaseSpecification<Product>
    {
        public GetAllProductsSpec(GetAllProductsQuery specParams) : base(AllProductsExpression.ExpressionSpec(specParams))
        {
            // Includes
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
            // Sorting
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
            // Pagination
            ApplyPaging(specParams.PageSize * (specParams.PageIndex - 1), specParams.PageSize, true);
        }


        public class ProductsCountSpec : BaseSpecification<Product>
        {
            public ProductsCountSpec(GetAllProductsQuery specParams) : base(AllProductsExpression.ExpressionSpec(specParams))
            { 
                IsPagingEnable = false;
            }
        }

        public static class AllProductsExpression
        {
            public static Expression<Func<Product, bool>> ExpressionSpec(GetAllProductsQuery specParams)
            {
                return c => (!specParams.BrandId.HasValue || c.ProductBrandId == specParams.BrandId) &&
                            (!specParams.TypeId.HasValue || c.ProductTypeId == specParams.TypeId) &&
                            (string.IsNullOrWhiteSpace(specParams.Search) || c.Title.ToLower().Contains(specParams.Search));
            }
        }
    }
}

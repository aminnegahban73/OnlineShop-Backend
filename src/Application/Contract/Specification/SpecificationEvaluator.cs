using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Contract.Specification
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery;

            if (specification.Predicate is not null)
                query = query.Where(specification.Predicate);

            if (specification.Includes.Any())
                query = specification.Includes.Aggregate(query, (current, value) => current.Include(value));

            if (specification.OrderBy is not null)
                query = query.OrderBy(specification.OrderBy);

            if (specification.OrderByDesc is not null)
                query = query.OrderByDescending(specification.OrderByDesc);

            if (specification.IsPagingEnable)
                query = query.Skip(specification.Skip).Take(specification.Take);

            return query;
        }
    }
}

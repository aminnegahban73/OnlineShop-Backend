using Domain.Common;
using System.Linq.Expressions;

namespace Application.Contract.Specification
{
    public class BaseSpecification<T> : ISpecification<T> where T : BaseEntity
    {
        public Expression<Func<T, bool>> Predicate { get; }
        public List<Expression<Func<T, object>>> Includes => new();

        public BaseSpecification() { }

        public BaseSpecification(Expression<Func<T, bool>> criteria)
        {
            Predicate = criteria;
        }

        protected void AddIncludes(Expression<Func<T, object>> include)
        {
            Includes.Add(include);
        }
    }
}

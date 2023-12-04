using Domain.Common;
using System.Linq.Expressions;

namespace Application.Contract.Specification
{
    public interface ISpecification<T>where T : BaseEntity
    {
        Expression<Func<T, bool>> Predicate { get; }
        List<Expression<Func<T, object>>> Includes { get;}

    }
}

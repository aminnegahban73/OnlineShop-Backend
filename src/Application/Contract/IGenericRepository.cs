using Application.Contract.Specification;
using Domain.Common;
using System.Linq.Expressions;

namespace Application.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
        Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken);
        Task<T> AddAsync(T entity, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(T entity, CancellationToken cancellationToken);
        
        //Expression x=>x.Id
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
        Task<bool> AnyAsync(CancellationToken cancellationToken);

        //Specification
        Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken);
        Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken);
        Task<int> CountAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken);
    }
}

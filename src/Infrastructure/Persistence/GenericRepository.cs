﻿using Application.Contract;
using Application.Contract.Specification;
using Domain.Common;
using Infrastructure.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    internal class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cancellationToken)
        {
            var a = await _dbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);

            return a;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.ToListAsync(cancellationToken);
        }

        public async Task<T> AddAsync(T entity, CancellationToken cancellationToken)
        {
            await _dbSet.AddAsync(entity, cancellationToken);
            return await Task.FromResult(entity);
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            _dbSet.Entry(entity).State = EntityState.Modified;
            return await Task.FromResult(entity);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken)
        {
            var record = await GetByIdAsync(entity.Id, cancellationToken);
            record.IsDelete = true;
            await UpdateAsync(record, cancellationToken);
        }


        //
        public async Task<bool> AnyAsync(CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(cancellationToken);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
        {
            return await _dbSet.AnyAsync(expression, cancellationToken);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbSet.Where(expression);
        }

        public async Task<T> GetEntityWithSpec(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<T>> ListAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await ApplySpecification(spec).ToListAsync(cancellationToken);
        }

        public async Task<int> CountAsyncSpec(ISpecification<T> spec, CancellationToken cancellationToken)
        {
            return await ApplySpecification(spec).CountAsync(cancellationToken);
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_dbSet.AsQueryable(), spec);
        }
    }
}

﻿using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Application.Contract.Specification
{
    public class SpecificationEvaluator<T> where T : BaseEntity
    {
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> specification)
        {
            var query = inputQuery.AsQueryable();

            if (specification.Predicate != null)
                query.Where(specification.Predicate);

            if (specification.Includes.Any())
                query = specification.Includes.Aggregate(query, (current, value) => current.Include(value));

            return query;
        }
    }
}
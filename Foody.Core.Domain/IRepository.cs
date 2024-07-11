﻿using Foody.Core.Domain.Entities.Base;
using System.Linq.Expressions;

namespace Foody.Core.Domain
{
    public interface IRepository<T> where T : Entity
    {
        Task<T> CreateAsync(T entity, CancellationToken cancellationToken);
        Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool readOnly = false, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes);
        Task<List<T>> Get(CancellationToken cancellationToken, Expression<Func<T, bool>>? filter = null, bool readOnly = true, bool ignoreQueryFilters = false, Expression<Func<T, object>>[]? includes = null);
        Task<T> UpdateAsync(T entity, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
    }
}

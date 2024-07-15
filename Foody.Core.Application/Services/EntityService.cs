using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Interfaces;
using System.Linq.Expressions;

namespace Foody.Core.Application.Services
{
    public class EntityService<T> : IEntityService<T> where T : Entity
    {
        private readonly IRepository<T> _repository;

        public EntityService(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            return await _repository.CreateAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(id, cancellationToken);
        }

        public async Task<List<T>> Get(CancellationToken cancellationToken, Expression<Func<T, bool>>? filter = null, bool readOnly = true, bool ignoreQueryFilters = false, Expression<Func<T, object>>[]? includes = null)
        {
            return await _repository.GetAsync(cancellationToken, filter, readOnly, ignoreQueryFilters, includes);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool readOnly = false, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes)
        {
            return await _repository.GetByIdAsync(id, cancellationToken, readOnly, ignoreQueryFilters, includes);
        }

        public async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            return await _repository.UpdateAsync(entity, cancellationToken);
        }

    }
}

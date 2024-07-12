using Foody.Core.Domain.Entities.Base;
using Foody.Core.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq.Expressions;

namespace Foody.Infrastructure.Persistence.Repository
{
    public class Repository<T>: IRepository<T> where T : Entity
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context) {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<T> CreateAsync(T entity, CancellationToken cancellationToken)
        {
            using (await BeginTransactionAsync())
            {
                try
                {
                    await _dbSet.AddAsync(entity, cancellationToken);
                    await SaveChangesAsync(cancellationToken);
                    await CommitAsync(cancellationToken);
                    return entity;
                }
                catch (Exception)
                {
                    await RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        public virtual async Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            using (await BeginTransactionAsync())
            {
                try
                {
                    var entity = await GetByIdAsync(id, cancellationToken);
                    if (entity is null) return;
                    _context.Set<T>().Remove(entity);
                    await SaveChangesAsync(cancellationToken);
                    await CommitAsync(cancellationToken);
                }
                catch
                {
                    await RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        public virtual async Task<List<T>> Get(CancellationToken cancellationToken, Expression<Func<T, bool>>? filter = null, bool readOnly = true, bool ignoreQueryFilters = false, Expression<Func<T, object>>[]? includes = null)
        {
            IQueryable<T> query = _dbSet.AsQueryable();

            if (filter is not null) query = query.Where(filter);
            if (includes != null)
            {
                query = includes.Aggregate(query, (current, include) => current.Include(include));
            }

            if (readOnly) query = query.AsNoTracking();

            if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

            return await query.ToListAsync(cancellationToken);
        }

        public virtual async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken, bool readOnly = false, bool ignoreQueryFilters = false, params Expression<Func<T, object>>[] includes)
        {
            try
            {
                IQueryable<T> query = _dbSet.AsQueryable();

                // Aplicar includes opcionales
                if (includes != null)
                {
                    query = includes.Aggregate(query, (current, include) => current.Include(include));
                }

                if (readOnly) query = query.AsNoTracking();
                if (ignoreQueryFilters) query = query.IgnoreQueryFilters();

                T? entity = await query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
                return entity;
            }
            catch
            {
                throw;
            }
        }

        public virtual async Task<T> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            using (await BeginTransactionAsync())
            {
                try
                {
                    _dbSet.Update(entity);
                    await SaveChangesAsync(cancellationToken);
                    await CommitAsync(cancellationToken);
                    return entity;
                }
                catch
                {
                    await RollbackAsync(cancellationToken);
                    throw;
                }
            }
        }

        protected async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        protected async Task CommitAsync(CancellationToken cancellationToken)
        {
            await _context.Database.CommitTransactionAsync(cancellationToken);
        }

        protected async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        protected async Task RollbackAsync(CancellationToken cancellationToken)
        {
            if (_context.Database.CurrentTransaction != null)
            {
                await _context.Database.RollbackTransactionAsync(cancellationToken);
            }
        }

    }
}

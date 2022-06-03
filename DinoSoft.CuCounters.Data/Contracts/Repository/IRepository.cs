using DinoSoft.CuCounters.Data.Common.Model;
using System.Linq.Expressions;

namespace DinoSoft.CuCounters.Data.Contracts.Repository
{
    public interface IRepository<TKey, TEntity> where TEntity : class, IIdentityModel<TKey>
    {
        bool Any(Expression<Func<TEntity, bool>> predicate);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task Delete(TKey id, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<TEntity>> Get(CancellationToken cancellationToken);
        Task<IReadOnlyCollection<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);
        ValueTask<TEntity> Get(TKey id, CancellationToken cancellationToken = default);
        Task Insert(TEntity entity);
        Task Update(TEntity entity);
    }
}
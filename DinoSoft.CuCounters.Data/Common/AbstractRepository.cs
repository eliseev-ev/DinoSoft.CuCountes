using System.Linq.Expressions;
using System.Text.Json;
using DinoSoft.CuCounters.Data.Common.Extensions;
using DinoSoft.CuCounters.Data.Common.Model;
using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Common
{
    /// <summary>Абстрактный репозиторий.</summary>
    /// <typeparam name="TKey">Тип ключа.</typeparam>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    internal abstract class AbstractRepository<TKey, TEntity> : IRepository<TKey, TEntity> 
        where TEntity : class, IIdentityModel<TKey>
    {
        private readonly DbContext dataContext;

        /// <summary>Конструктор.</summary>
        /// <param name="context">Контекст данных.</param>
        protected AbstractRepository(DbContext context)
        {
            dataContext = context;
            DbSet = dataContext.Set<TEntity>();
        }

        /// <summary>Набор данных сущности <see cref="TEntity"/></summary>
        /// <typeparam name="TEntity">Тип сущности.</typeparam>
        protected DbSet<TEntity> DbSet { get; }

        /// <summary>Получить все сущности.</summary>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public async Task<IReadOnlyCollection<TEntity>> Get(CancellationToken cancellationToken)
        {
            return await DbSet.ToListAsync(cancellationToken);
        }

        /// <summary>Найти сущности.</summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public virtual async Task<IReadOnlyCollection<TEntity>> Get(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return await DbSet.Where(predicate).ToListAsync(cancellationToken);
        }

        /// <summary>Получить сущность по идентификатору.</summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public virtual ValueTask<TEntity> Get(TKey id, CancellationToken cancellationToken = default)
        {
            return DbSet.FindAsync(new object[] { id }, cancellationToken);
        }

        /// <summary>Найти сущность.</summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public virtual Task<TEntity> FirstOrDefault(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DbSet.FirstOrDefaultAsync(predicate, cancellationToken);
        }

        /// <summary>Проверить наличие.</summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public virtual Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default)
        {
            return DbSet.AnyAsync(predicate, cancellationToken);
        }

        /// <summary>Проверить наличие.</summary>
        /// <param name="predicate">Условие поиска.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public virtual bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return DbSet.Any(predicate);
        }

        /// <summary>Добавить сущность.</summary>
        /// <param name="entity">Экземпляр сущности.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public Task Insert(TEntity entity)
        {
            DbSet.Add(entity);
            return Task.CompletedTask;
        }

        /// <summary>Обновить сущность.</summary>
        /// <param name="entity">Экземпляр сущности.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public Task Update(TEntity entity)
        {
            DbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }

        /// <summary>Удалить сущность.</summary>
        /// <param name="id">Идентификатор.</param>
        /// <param name="cancellationToken">Токен отмены.</param>
        /// <returns><see cref="Task{TResult}"/></returns>
        public virtual async Task Delete(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await Get(id, cancellationToken);
            DbSet.Remove(entity);
        }

        /// <summary>Создать запрос.</summary>
        /// <param name="tracking">Отслеживать изменения.</param>
        /// <returns>Запрос.</returns>
        protected virtual IQueryable<TEntity> Query(bool tracking)
        {
            return DbSet.CreateQuery(tracking);
        }
    }
}

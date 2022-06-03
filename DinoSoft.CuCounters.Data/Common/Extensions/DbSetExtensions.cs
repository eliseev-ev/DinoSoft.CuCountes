using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Common.Extensions
{
    /// <summary>Расширения для <see cref="DbSet{TEntity}"/></summary>
    public static class DbSetExtensions
    {
        /// <summary>Создать запрос.</summary>
        /// <typeparam name="T">Тип сущности.</typeparam>
        /// <param name="dataSet"><see cref="DbSet{TEntity}"/></param>
        /// <param name="tracking">Отслеживать изменения.</param>
        /// <returns>Запрос.</returns>
        public static IQueryable<T> CreateQuery<T>(this DbSet<T> dataSet, bool tracking) where T : class
        {
            var query = dataSet.AsQueryable();

            if (!tracking)
            {
                query = query.AsNoTracking();
            }

            return query;
        }
    }
}

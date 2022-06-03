using System.Text.Json;
using DinoSoft.CuCounters.Data.Common;
using DinoSoft.CuCounters.Data.Contracts.Model;
using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Repository
{
    internal class CounterGroupRepository : AbstractRepository<Guid, Group>, ICounterGroupRepository
    {
        public CounterGroupRepository(DataContext context)
            : base(context)
        {
        }

        protected override IQueryable<Group> Query(bool tracking)
        {
            return base.Query(tracking)
                .Include(x => x.Counters)
                    .ThenInclude(x => x.CounterActions)
                .Include(x => x.Groups);
        }
    }
}

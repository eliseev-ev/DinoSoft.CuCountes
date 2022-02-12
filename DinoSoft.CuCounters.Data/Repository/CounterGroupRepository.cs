using System.Text.Json;
using DinoSoft.CuCounters.Data.Common;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DinoSoft.CuCounters.Data.Repository
{
    public class CounterGroupRepository : AbstractRepository<Guid, CounterGroup>
    {
        public CounterGroupRepository(DataContext context)
            : base(context)
        {
        }

        protected override IQueryable<CounterGroup> Query(bool tracking)
        {
            return base.Query(tracking)
                .Include(x => x.Counters)
                    .ThenInclude(x => x.CounterActions);
        }
    }
}

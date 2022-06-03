using DinoSoft.CuCounters.Data.Common;
using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Infrastructure;
using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Data.Repository
{
    internal class CounterRepository : AbstractRepository<Guid, Counter>, ICounterRepository
    {
        public CounterRepository(DataContext context)
            : base(context)
        {
        }
    }
}

using DinoSoft.CuCounters.Data.Common;
using DinoSoft.CuCounters.Data.Contracts.Model;
using DinoSoft.CuCounters.Data.Contracts.Repository;
using DinoSoft.CuCounters.Data.Infrastructure;

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

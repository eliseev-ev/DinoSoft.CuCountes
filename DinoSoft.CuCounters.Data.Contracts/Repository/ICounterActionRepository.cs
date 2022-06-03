using DinoSoft.CuCounters.Data.Contracts.Model;

namespace DinoSoft.CuCounters.Data.Contracts.Repository
{
    public interface ICounterActionRepository : IRepository<Guid, CounterAction>
    {
    }
}
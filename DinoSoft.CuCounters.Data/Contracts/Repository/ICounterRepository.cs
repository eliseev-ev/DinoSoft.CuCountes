using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Data.Contracts.Repository
{
    public interface ICounterRepository : IRepository<Guid, Counter>
    {
    }
}
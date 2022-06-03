using DinoSoft.CuCounters.Data.Model;

namespace DinoSoft.CuCounters.Data.Contracts.Repository
{
    public interface ICounterGroupRepository : IRepository<Guid, Group>
    {
    }
}